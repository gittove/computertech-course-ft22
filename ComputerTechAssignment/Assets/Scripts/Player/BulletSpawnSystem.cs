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
    private float nextTime = 0.0f;

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

        Entities.WithAll<PlayerTag>().ForEach((Entity entity, int entityInQueryIndex, in Translation translation, in Rotation rotation,
            in BulletSpawnOffsetComponent bulletOffset) =>
        {
            if (shoot != 1 || !canShoot)
            {
                return;
            }

            var bulletEntity = commandBuffer.Instantiate(entityInQueryIndex, bulletprefab);

            var newPosition = new Translation { Value = translation.Value + math.mul(rotation.Value, bulletOffset.Value).xyz };
            commandBuffer.SetComponent(entityInQueryIndex, bulletEntity, newPosition);

            var movement = new MovementComponent { direction = new float3(0, 0, 1) * math.mul(rotation.Value, new float3(0, 0, 1)).xyz };
            movement.movementSpeed = 10;
            commandBuffer.SetComponent(entityInQueryIndex, bulletEntity, movement);
        }).ScheduleParallel();

        BeginSimECB.AddJobHandleForProducer(Dependency);
    }
}
