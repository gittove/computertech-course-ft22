using Unity.Entities;

[GenerateAuthoringComponent]
public struct LifetimeComponent : IComponentData
{
    public float age;
    public float maxAge;

    public LifetimeComponent(float maxAge)
    {
        this.maxAge = maxAge;
        age = 0;
    }
}
