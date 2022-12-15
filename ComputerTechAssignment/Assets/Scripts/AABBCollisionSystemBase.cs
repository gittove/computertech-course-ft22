using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

public partial class AABBCollisionSystemBase : SystemBase
{
    protected override void OnUpdate()
    {
        OctreeComponent octree = GetSingleton<OctreeComponent>();

        Entities.ForEach(( in AABBComponent aabb, in Translation translation) =>
        {
            
            
            // TODO check translation in octree
        }).Schedule();
    }
}
