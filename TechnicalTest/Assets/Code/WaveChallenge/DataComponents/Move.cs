using UnityEngine;
using Unity.Entities;

[GenerateAuthoringComponent]
public struct Move : IComponentData
{
    public float m_movementSpeed;
    public Vector3 m_startPosition;


}
