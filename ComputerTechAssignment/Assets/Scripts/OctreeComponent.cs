using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public struct OctreeComponent : IComponentData
{
    //public float minNodeSize;
    //public OctreeNodeComponent root;
    //public OctreeComponent(List<Vector3> aabb, float size)
    //{
    //    Bounds treeBounds = new Bounds();
    //    treeBounds.size = new Vector3(size, size, size);
    //    minNodeSize = size * 0.3f;

    //    float maxSize = Mathf.Max(treeBounds.size.x, treeBounds.size.y, treeBounds.size.z);
    //    Vector3 sizeVector = new Vector3(maxSize, maxSize, maxSize);
    //    treeBounds.SetMinMax(treeBounds.center - sizeVector, treeBounds.center + sizeVector);

    //    root = new OctreeNodeComponent();
    //    AddObjects(aabb);
    //}

    //private void AddObjects(List<Vector3> aabbs)
    //{
    //    foreach(var go in aabbs)
    //    {
    //        root.AddObject(go);
    //    }
    //}
}
