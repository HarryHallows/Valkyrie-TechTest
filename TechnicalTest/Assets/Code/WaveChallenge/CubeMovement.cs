using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime;
        transform.position = startPosition + new Vector3(transform.position.x, Mathf.Sin(Time.time), transform.position.z);
    }
}
