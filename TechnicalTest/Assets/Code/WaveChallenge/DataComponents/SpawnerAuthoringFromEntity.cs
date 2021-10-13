using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class SpawnerAuthoringFromEntity : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
{

    public GameObject prefab;
    public int countX;
    public int countY;

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(prefab);
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var spawnerData = new SpawnFromEntity
        {
            // The referenced prefab will be converted due to DeclareReferencedPrefabs.
            // So here we simply map the game object to an entity reference to that prefab.
            Prefab = conversionSystem.GetPrimaryEntity(prefab),
            CountX = countX,
            CountY = countY
        };
        dstManager.AddComponentData(entity, spawnerData);
    }

    
}
