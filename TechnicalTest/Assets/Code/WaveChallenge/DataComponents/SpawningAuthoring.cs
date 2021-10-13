using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class SpawningAuthoring : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float spawnRate;
    [SerializeField] private float maxDistance;
    
    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(prefab);
    }
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new Spawner
        {
            s_prefab = conversionSystem.GetPrimaryEntity(prefab),
            s_maxDistance = maxDistance,
            s_secondsBetweenSpawns = 1f / spawnRate,
            s_timeUntilNextSpawn = 0f
        });
    }
}
