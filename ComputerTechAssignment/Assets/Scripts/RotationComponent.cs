using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct RotationComponent : IComponentData
{
    public float3 direction;
    public int rotationSpeed;
    public float3 torque;
}
