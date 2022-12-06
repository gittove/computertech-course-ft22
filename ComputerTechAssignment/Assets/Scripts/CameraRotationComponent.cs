using Unity.Entities;

[GenerateAuthoringComponent]
public struct CameraRotationComponent : IComponentData
{
    public bool bIsRightMouseClicked;
    public float cameraLookAroundClampAngle;
}
