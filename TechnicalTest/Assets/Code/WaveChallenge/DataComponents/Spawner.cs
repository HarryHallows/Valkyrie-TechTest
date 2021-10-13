using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public struct Spawner : IComponentData
{
    //Spawning prefab
    public Entity s_prefab;
    public float s_maxDistance;
    public float s_secondsBetweenSpawns;
    public float s_timeUntilNextSpawn;
}
