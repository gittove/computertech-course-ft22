using UnityEngine;
using Unity.Entities;

public class TransformConverter : MonoBehaviour, IConvertGameObjectToEntity
{
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentObject(entity, this.GetComponent<Transform>());
    }
}
