using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Jobs;
using System.Diagnostics;
using UnityEngine;

public partial class AsteroidSpawnSystem : SystemBase
{
    private EntityQuery asteroidQuery;

    private BeginSimulationEntityCommandBufferSystem BeginSimECB;

    private Entity prefab;

    private float lastSpawnTime;

    protected override void OnCreate()
    {
        asteroidQuery = GetEntityQuery(ComponentType.ReadWrite<AsteroidTag>());

        BeginSimECB = World.GetOrCreateSystem<BeginSimulationEntityCommandBufferSystem>();
    }

    protected override void OnUpdate()
    {
        if (prefab == Entity.Null)
        {
            prefab = GetSingleton<AsteroidAuthoringComponent>().prefab;
            return;
        }

        var commandBuffer = BeginSimECB.CreateCommandBuffer();
        var cout = asteroidQuery.CalculateEntityCountWithoutFiltering();
        var asteroidPrefab = prefab;
        var rand = new Unity.Mathematics.Random((uint)Stopwatch.GetTimestamp());

        float spawnInterval = GetSingleton<AsteroidAuthoringComponent>().spawnIntervalSeconds;
        int spawnRadius = GetSingleton<AsteroidAuthoringComponent>().spawnRadiusMeters;

        float time = UnityEngine.Time.time;
        float diff = time - lastSpawnTime;

        if (diff <= spawnInterval)
        {
            return;
        }

        lastSpawnTime = UnityEngine.Time.time;

        float3 spawnerPosition = new float3(0.0f, 0.0f, 0.0f);
        Entities.WithoutBurst().ForEach((Transform transform, in AsteroidAuthoringComponent comp) =>
        {
            spawnerPosition = transform.position;
        }).Run();

        Job.WithCode(() =>
        {
            float3 spawnPosition;
            spawnPosition.x = rand.NextFloat(spawnerPosition.x - spawnRadius, spawnerPosition.x + spawnRadius);
            spawnPosition.y = spawnerPosition.y;
            spawnPosition.z = rand.NextFloat(spawnerPosition.z - spawnRadius, spawnerPosition.z + spawnRadius);
            Translation pos = new Translation { Value = new float3(spawnPosition) };

            var e = commandBuffer.Instantiate(asteroidPrefab);
            commandBuffer.SetComponent(e, pos);

            var MovementComp = new MovementComponent { movementSpeed = 2 };
            MovementComp.direction = new float3(0, -1, 0);
            commandBuffer.SetComponent(e, MovementComp);
        }).Schedule();

        //This will add our dependency to be played back on the BeginSimulationEntityCommandBuffer
        BeginSimECB.AddJobHandleForProducer(Dependency);
    }
}
