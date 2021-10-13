using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;

public class SpawnController : MonoBehaviour
{
    public GameObject prefab;
    private Entity cubeEntity;
    private EntityManager entityManager;
    private BlobAssetStore blobAssetStore;

    private static RenderMesh cubeRenderer;

    public static void Initialise()
    {

    }

    private void Awake()
    {
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        blobAssetStore = new BlobAssetStore();
        GameObjectConversionSettings settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, blobAssetStore);
        cubeEntity = GameObjectConversionUtility.ConvertGameObjectHierarchy(prefab, settings);
    }

    private void Update()
    {
        Entity newCubeEntity = entityManager.Instantiate(cubeEntity);
    }

}
