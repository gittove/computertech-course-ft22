using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public partial class CameraInputSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float3 mouseInputAxis = new float3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);

        Entities.WithAll<CameraTag>().ForEach((ref RotationComponent rotationComponent, in CameraRotationComponent rotationData) =>
        {
            rotationComponent.direction.xyz = mouseInputAxis;

            if (!rotationData.bIsRightMouseClicked)
            {
                rotationComponent.direction.x = Mathf.Clamp(rotationComponent.direction.x,
                    -rotationData.cameraLookAroundClampAngle,
                    rotationData.cameraLookAroundClampAngle);
                rotationComponent.direction.y = Mathf.Clamp(rotationComponent.direction.y,
                    -rotationData.cameraLookAroundClampAngle,
                    rotationData.cameraLookAroundClampAngle);
            }
        }).Schedule();
    }
}
