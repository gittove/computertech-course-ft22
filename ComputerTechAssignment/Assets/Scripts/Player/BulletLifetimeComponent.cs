using Unity.Entities;

[GenerateAuthoringComponent]
public struct BulletLifetimeComponent : IComponentData
{
    public float age;
    public float maxAge;

    public BulletLifetimeComponent(float maxAge)
    {
        this.maxAge = maxAge;
        age = 0;
    }
}
