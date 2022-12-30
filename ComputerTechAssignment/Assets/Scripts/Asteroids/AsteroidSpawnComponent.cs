using Unity.Entities;

[GenerateAuthoringComponent]
public struct AsteroidSpawnComponent : IComponentData
{
    public int spawnRadiusMeters;
    public float spawnIntervalSeconds;

    public Entity prefab;
}
