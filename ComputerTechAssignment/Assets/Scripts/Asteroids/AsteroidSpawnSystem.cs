using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Jobs;
using Unity.Burst;
using System.Diagnostics;
using Unity.Collections;


public partial class AsteroidSpawnSystem : SystemBase
{
    private EntityQuery asteroidQuery;

    private BeginSimulationEntityCommandBufferSystem BeginSimECB;

    private Entity prefab;

    //private int spawnRadius;

    private float spawnTimer;
    private float spawnInterval;

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

        spawnInterval = GetSingleton<AsteroidAuthoringComponent>().spawnIntervalSeconds;
        int spawnRadius = GetSingleton<AsteroidAuthoringComponent>().spawnRadiusMeters;

        float deltaTime = Time.DeltaTime;

        Job.WithCode(() =>
        {
           float3 playerPosition = new float3(0.0f, 0.0f, 0.0f);

           float3 spawnPosition;
           spawnPosition.x = rand.NextFloat(playerPosition.x - spawnRadius, playerPosition.x + spawnRadius);
           spawnPosition.y = playerPosition.y;
           spawnPosition.z = rand.NextFloat(playerPosition.z - spawnRadius, playerPosition.z + spawnRadius);
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
