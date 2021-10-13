using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Jobs;
using Random = Unity.Mathematics.Random;
using Time = UnityEngine.Time;

public class SpawnerSystem : JobComponentSystem
{
    private EndSimulationEntityCommandBufferSystem endSimulationEntityCommandBufferSystem;

    protected override void OnCreate()
    {
        endSimulationEntityCommandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
    }


    private struct SpawnerJob : IJobForEachWithEntity<Spawner, LocalToWorld>
    {
        public EntityCommandBuffer.ParallelWriter entityCommandBuffer;

        private Random random; 
        private readonly float deltaTime;

        public SpawnerJob(EntityCommandBuffer.ParallelWriter _entityCommandBuffer,Random _random, float _deltaTime)
        {
            this.entityCommandBuffer = _entityCommandBuffer;
            this.random = _random;
            this.deltaTime = _deltaTime;
        }

        public void Execute(Entity entity, int index, ref Spawner spawner, [ReadOnly] ref LocalToWorld localToWorld)
        {
            spawner.s_timeUntilNextSpawn -= deltaTime;

            if (spawner.s_timeUntilNextSpawn >= 0)
            {
                return;
            }

            spawner.s_timeUntilNextSpawn += spawner.s_secondsBetweenSpawns;

            Entity instance = entityCommandBuffer.Instantiate(index, spawner.s_prefab);
            entityCommandBuffer.SetComponent(index, instance, new Translation
            {
                Value = localToWorld.Position + random.NextFloat3Direction() * random.NextFloat() * spawner.s_maxDistance
            });
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var spawnerJob = new SpawnerJob(
            endSimulationEntityCommandBufferSystem.CreateCommandBuffer().AsParallelWriter(),
            new Random((uint)UnityEngine.Random.Range(0, int.MaxValue)),
            Time.DeltaTime
            );

        JobHandle jobHandle = spawnerJob.Schedule(this, inputDeps);

        endSimulationEntityCommandBufferSystem.AddJobHandleForProducer(jobHandle);

        return jobHandle;
    }
}
