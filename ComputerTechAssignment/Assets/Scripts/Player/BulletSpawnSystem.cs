using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class BulletSpawnSystem : SystemBase
{
    private EntityQuery playerQuery;
    private BeginSimulationEntityCommandBufferSystem BeginSimECB;
    private Entity bulletPrefab;

    private float perSecond = 10.0f;
    private float nextTime = 0.3f;

    protected override void OnCreate()
    {
        playerQuery = GetEntityQuery(ComponentType.ReadWrite<PlayerTag>());

        BeginSimECB = World.GetOrCreateSystem<BeginSimulationEntityCommandBufferSystem>();
    }

    protected override void OnUpdate()
    {
        if (bulletPrefab == Entity.Null)
        {
            bulletPrefab = GetSingleton<BulletAuthoringComponent>().prefab;

            return;
        }

        byte shoot;
        shoot = 0;

        if (Input.GetKey("space"))
        {
            shoot = 1;
        }

        var commandBuffer = BeginSimECB.CreateCommandBuffer().AsParallelWriter();

        var bulletprefab = bulletPrefab;

        var canShoot = false;

        if (UnityEngine.Time.time >= nextTime)
        {
            canShoot = true;
            nextTime += (1 / perSecond);
        }

        float3 playerPosition = new float3(0, 0, 0);
        float3 playerForward = new float3(0, 0, 0);
        quaternion playerRotation = new quaternion(0, 0, 0, 0);

        Entities.WithAll<PlayerTag>().WithoutBurst().ForEach((Transform transform) =>
        {
            playerPosition = new float3(transform.position.x, transform.position.y, transform.position.z);
            playerForward = new float3(transform.forward.x, transform.forward.y, transform.forward.z);
            playerRotation = new quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        }).Run();

        Entities.WithAll<PlayerTag>().ForEach((Entity entity, int entityInQueryIndex, in Rotation rotation,
            in BulletSpawnOffsetComponent bulletOffset) =>
        {
            if (shoot != 1 || !canShoot)
            {
                return;
            }

            var bulletEntity = commandBuffer.Instantiate(entityInQueryIndex, bulletprefab);

            var newPosition = new Translation { Value = playerPosition + math.mul(playerRotation, bulletOffset.Value).xyz };
            commandBuffer.SetComponent(entityInQueryIndex, bulletEntity, newPosition);

            var movement = new MovementComponent { direction = playerForward };
            movement.movementSpeed = 100;
            commandBuffer.AddComponent(entityInQueryIndex, bulletEntity, movement);
        }).ScheduleParallel();

        BeginSimECB.AddJobHandleForProducer(Dependency);
    }
}
