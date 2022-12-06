using UnityEngine;
using Unity.Entities;

public partial class PlayerInputSystemBase : SystemBase
{
    protected override void OnUpdate()
    {
        float inputx = Input.GetAxis("Horizontal");
        float inputy = Input.GetAxis("Vertical");

        Entities.WithAll<PlayerTag>().ForEach((ref MovementComponent movementData) =>
        {
            movementData.direction.x = inputx;
            movementData.direction.z = inputy;
        }).Schedule();
    }
}
