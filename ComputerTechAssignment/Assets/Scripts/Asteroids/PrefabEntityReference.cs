using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public struct PrefabEntityReference : IComponentData
{
    public Entity Prefab;
}
