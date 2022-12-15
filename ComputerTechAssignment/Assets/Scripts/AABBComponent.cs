using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

[GenerateAuthoringComponent]
public struct AABBComponent : IComponentData
{
    public float height;
    public float width;
}
