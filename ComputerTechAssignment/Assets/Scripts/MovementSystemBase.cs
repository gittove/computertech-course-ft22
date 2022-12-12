using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public partial class MovementSystemBase : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities.WithoutBurst().ForEach((ref Translation t, in MovementComponent movementData) => 
        {
            float acceleration_right = movementData.direction.x * movementData.movementSpeed * deltaTime;
            float acceleration_up = movementData.direction.y * movementData.movementSpeed * deltaTime;
            float acceleration_forward = movementData.direction.z * movementData.movementSpeed * deltaTime;

            float3 acceleration = new float3(0, 0, 0);
            acceleration.x = acceleration_right;
            acceleration.y = acceleration_up;
            acceleration.z = acceleration_forward;

            t.Value.xyz += acceleration;
            //transform.localPosition = t.Value;
        }).Run();
    }
}
