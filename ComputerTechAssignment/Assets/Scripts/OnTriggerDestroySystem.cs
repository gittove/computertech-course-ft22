using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Collections;
using Unity.Jobs;
using Unity.Physics.Stateful;
using Unity.Rendering;

public partial class OnTriggerDestroySystem : SystemBase
{
    private EndFixedStepSimulationEntityCommandBufferSystem m_CommandBufferSystem;

    private EntityQueryMask m_NonTriggerMask;

    protected override void OnCreate()
    {
        m_CommandBufferSystem = World.GetOrCreateSystem<EndFixedStepSimulationEntityCommandBufferSystem>();
        m_NonTriggerMask = EntityManager.GetEntityQueryMask(
            GetEntityQuery(new EntityQueryDesc
            {
                None = new ComponentType[]
                {
                    typeof(StatefulTriggerEvent)
                }
            })
        );
    }

    protected override void OnUpdate()
    {
        var commandBuffer = m_CommandBufferSystem.CreateCommandBuffer();
        var nonTriggerMask = m_NonTriggerMask;

        Entities
            .WithName("DestroyOnTriggerEnter")
            .WithoutBurst()
            .ForEach((Entity e, ref DynamicBuffer<StatefulTriggerEvent> triggerEventBuffer) =>
            {
                for (int i = 0; i < triggerEventBuffer.Length; i++)
                {
                    var triggerEvent = triggerEventBuffer[i];
                    var otherEntity = triggerEvent.GetOtherEntity(e);

                    if (triggerEvent.State == StatefulEventState.Stay || !nonTriggerMask.Matches(otherEntity))
                    {
                        continue;
                    }

                    if (triggerEvent.State == StatefulEventState.Enter)
                    {
                        var volumeRenderMesh = EntityManager.GetSharedComponentData<RenderMesh>(e);
                        var overlappingRenderMesh = EntityManager.GetSharedComponentData<RenderMesh>(otherEntity);
                        overlappingRenderMesh.material = volumeRenderMesh.material;

                        commandBuffer.SetSharedComponent(otherEntity, overlappingRenderMesh);
                    }
                    
                    else
                    {
                        commandBuffer.AddComponent(otherEntity, new DestroyTag { });
                    }
                }
            }).Run();

        m_CommandBufferSystem.AddJobHandleForProducer(Dependency);
    }
}
