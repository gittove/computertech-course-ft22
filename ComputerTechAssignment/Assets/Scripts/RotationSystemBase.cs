using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

public partial class RotationSystemBase : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Rotation r, in RotationComponent rotationComponent) =>
        {
            r.Value = Quaternion.Euler(rotationComponent.torque);
        }).Schedule();
    }
}
