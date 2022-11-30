using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[GenerateAuthoringComponent]
public struct HealthComponent : IComponentData
{
    [SerializeField] public int health;
}
