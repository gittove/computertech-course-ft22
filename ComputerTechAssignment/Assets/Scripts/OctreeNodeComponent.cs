using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public struct OctreeNodeComponent : IComponentData
{
    //public float minNodeSize;
    //public Bounds bounds;
    //public Bounds[] childBounds;
    //public OctreeNodeComponent[] children;
    //public List<Vector3> aabb;

    //public OctreeNodeComponent(Bounds bounds, float minNodeSize)
    //{
    //    this.minNodeSize = minNodeSize;
    //    this.bounds = bounds;
    //    aabb = new List<Vector3>();

    //    float quarterSize = bounds.size.y * 0.25f;
    //    Vector3 childSize = new Vector3(bounds.size.x * 0.5f, bounds.size.y * 0.5f, bounds.size.z * 0.5f);
    //    childBounds = new Bounds[8];

    //    childBounds[0] = new Bounds(bounds.center + new Vector3(-quarterSize, quarterSize, -quarterSize), childSize);
    //    childBounds[1] = new Bounds(bounds.center + new Vector3(quarterSize, quarterSize, -quarterSize), childSize);
    //    childBounds[2] = new Bounds(bounds.center + new Vector3(-quarterSize, quarterSize, quarterSize), childSize);
    //    childBounds[3] = new Bounds(bounds.center + new Vector3(quarterSize, quarterSize, quarterSize), childSize);
    //    childBounds[4] = new Bounds(bounds.center + new Vector3(-quarterSize, -quarterSize, -quarterSize), childSize);
    //    childBounds[5] = new Bounds(bounds.center + new Vector3(quarterSize, -quarterSize, -quarterSize), childSize);
    //    childBounds[6] = new Bounds(bounds.center + new Vector3(-quarterSize, -quarterSize, quarterSize), childSize);
    //    childBounds[7] = new Bounds(bounds.center + new Vector3(quarterSize, -quarterSize, quarterSize), childSize);

    //    children = new OctreeNodeComponent[8];
    //}

    //public void AddObject(Vector3 add)
    //{
    //    DivideAndAdd(add);
    //}

    //private void DivideAndAdd(Vector3 obj)
    //{
    //    if (bounds.size.y <= minNodeSize)
    //    {
    //        aabb.Add(obj);
    //        return;
    //    }

    //    bool dividing = false;

    //    for (int i = 0; i < 8; i++)
    //    {
    //        children[i] = new OctreeNodeComponent(childBounds[i], minNodeSize);

    //        if (IsIntersecting(childBounds[i], obj))
    //        {
    //            dividing = true;
    //            children[i].DivideAndAdd(obj);
    //        }
    //    }

    //    if (!dividing)
    //    {
    //        aabb.Add(obj);
    //        children = null;
    //    }
    //}

    //private bool IsIntersecting(Bounds childBounds, Vector3 objectPosition)
    //{
    //    return (objectPosition.x >= childBounds.min.x &&
    //            objectPosition.x <= childBounds.max.x &&
    //            objectPosition.y >= childBounds.min.y &&
    //            objectPosition.y <= childBounds.max.y &&
    //            objectPosition.z >= childBounds.min.z &&
    //            objectPosition.z <= childBounds.max.z);
    //}

    //private bool IsIntersecting(Bounds boundsA, Bounds boundsB)
    //{
    //    return (boundsA.max.x >= boundsB.min.x &&
    //            boundsA.min.x <= boundsB.max.x &&
    //            boundsA.max.y >= boundsB.min.y &&
    //            boundsA.min.y <= boundsB.max.y &&
    //            boundsA.max.z >= boundsB.min.z &&
    //            boundsA.min.z <= boundsB.max.z);
    //}
}
