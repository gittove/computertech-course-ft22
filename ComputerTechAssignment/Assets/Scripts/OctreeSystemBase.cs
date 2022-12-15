using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public partial class OctreeSystemBase : SystemBase
{
    List<Entity> components;

    protected override void OnCreate()
    {
        components = new List<Entity>();
    }

    protected override void OnUpdate()
    {
        components.Clear();

        Entities.ForEach((in Entity ent, in AABBComponent aabb) =>
        {
            //components.Add(ent);
        }).Run();

        //SetSingleton<OctreeComponent>(new OctreeComponent(components, 100.0f));
    }
}
