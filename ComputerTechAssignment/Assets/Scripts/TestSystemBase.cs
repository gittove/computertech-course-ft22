using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public partial class TestSystemBase : SystemBase
{
    EntityQuery query;

    protected override void OnCreate()
    {
        //base.OnCreate();
        var queryDesc = new EntityQueryDesc { All = new ComponentType[] { typeof(HealthComponent) } };
        query = GetEntityQuery(queryDesc);
        
    }

    protected override void OnUpdate()
    {
        //Entities.ForEach((ref HealthComponent health) => { health.health += 1; Debug.Log("current health: " + health.health); }).Run();
        Entities.ForEach((ref HealthComponent health) => { health.health += 1; Debug.Log("current health: " + health.health); }).Schedule();
    }
}
