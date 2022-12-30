using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public partial class LifetimeSystem : SystemBase
{
    private BeginSimulationEntityCommandBufferSystem beginSimEcb;
    protected override void OnCreate()
    {
        beginSimEcb = World.GetOrCreateSystem<BeginSimulationEntityCommandBufferSystem>();
    }

    protected override void OnUpdate()
    {
        var commandBuffer = beginSimEcb.CreateCommandBuffer().AsParallelWriter();

        float deltaTime = Time.DeltaTime;

        Entities.ForEach((Entity entity, int entityInQueryIndex, ref LifetimeComponent age) =>
        {
            age.age += deltaTime;
            if (age.age > age.maxAge)
            {
                commandBuffer.DestroyEntity(entityInQueryIndex, entity);
            }
        }).ScheduleParallel();
        beginSimEcb.AddJobHandleForProducer(Dependency);
    }

}
