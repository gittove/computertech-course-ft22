using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public partial class HealthSystemBase : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref HealthComponent health) => { health.health += 1; }).Schedule();
    }

    void DealDamage()
    {

    }

    void HealDamage()
    {

    }
}
