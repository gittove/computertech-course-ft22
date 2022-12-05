using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public partial class MovementSystemBase : SystemBase
{
    protected override void OnUpdate()
    {
        float3 direction = new float3(0,0,0);

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        float acceleration_right = direction.x * 50 * Time.DeltaTime;
        float acceleration_forward = direction.z * 50 * Time.DeltaTime;

        float3 acceleration = new float3(0, 0, 0);
        acceleration.x = acceleration_right;
        acceleration.z = acceleration_forward;

        Entities.ForEach((ref Translation t) => 
        {
            t.Value.xyz += acceleration;
        }).Schedule();
    }
}
