using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public partial class DestructionSystemBase : SystemBase
{
    private EndSimulationEntityCommandBufferSystem EndSimECB;
    protected override void OnCreate()
    {
        EndSimECB = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
    }

    protected override void OnUpdate()
    {
        var commandBuffer = EndSimECB.CreateCommandBuffer().AsParallelWriter();

        Entities.WithAll<DestroyTag>().ForEach((Entity entity, int entityInQueryIndex) =>
        {
            commandBuffer.DestroyEntity(entityInQueryIndex, entity);
        }).ScheduleParallel();

        EndSimECB.AddJobHandleForProducer(Dependency);
    }
}
