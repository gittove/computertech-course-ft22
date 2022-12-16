using Unity.Entities;

[GenerateAuthoringComponent]
public struct AsteroidSpawnComponent : IComponentData
{
    public float spawnInterval;
    public float lastSpawnTime;
}
