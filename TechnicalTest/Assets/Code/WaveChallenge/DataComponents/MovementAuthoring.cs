using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class MovementAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    [SerializeField] private float movementPerSecond;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {

    }

}
