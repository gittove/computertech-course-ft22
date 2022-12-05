using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct MovementComponent : IComponentData
{
    public int movementSpeed;
    public float3 velocity;
    public float3 direction;

    public int rotationSpeed;
    public float3 torque;
}
