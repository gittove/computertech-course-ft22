using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

[GenerateAuthoringComponent]
public struct AsteroidAuthoringComponent : IComponentData
{
    public int spawnRadiusMeters;
    public int spawnIntervalSeconds;

    public Entity prefab;
}
