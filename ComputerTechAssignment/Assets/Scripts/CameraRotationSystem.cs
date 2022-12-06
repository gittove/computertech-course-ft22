using Unity.Entities;
using Unity.Mathematics;

public partial class CameraRotationSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities.WithAll<CameraTag>().ForEach((ref RotationComponent rotationData) =>
        {
            rotationData.torque = new float3(rotationData.direction.x * rotationData.rotationSpeed * deltaTime,
                rotationData.direction.y * rotationData.rotationSpeed * deltaTime,
                rotationData.direction.z * rotationData.rotationSpeed * deltaTime);
        }).Schedule();
    }
}
