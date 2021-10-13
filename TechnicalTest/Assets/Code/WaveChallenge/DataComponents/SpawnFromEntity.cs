using Unity.Entities;
public struct SpawnFromEntity : IComponentData
{
    public int CountX;
    public int CountY;
    public Entity Prefab;
}
