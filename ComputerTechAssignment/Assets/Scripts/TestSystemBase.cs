using UnityEngine;
using Unity.Entities;

public partial class TestSystemBase : SystemBase
{
    //EntityQuery query;

    //protected override void OnCreate()
    //{
    //    //base.OnCreate();
    //    var queryDesc = new EntityQueryDesc { All = new ComponentType[] { typeof(HealthComponent) } };
    //    query = GetEntityQuery(queryDesc);
        
    //}

    protected override void OnUpdate()
    {
        float nonsense = 0.0f;
    }
}
