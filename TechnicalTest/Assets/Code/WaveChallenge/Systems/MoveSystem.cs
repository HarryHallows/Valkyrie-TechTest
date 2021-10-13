using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Mathematics;

public class MoveSystem : JobComponentSystem
{
    //DOTS version of Update
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref Translation translation, in Move moveData) =>
        {
            translation.Value.z += moveData.m_movementSpeed * deltaTime;
            translation.Value.y += math.sin(deltaTime) * moveData.m_movementSpeed;
        }).Run();

        return default;
    }
}
