using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CameraController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
     private float horizontal, vertical;
    [SerializeField] private Vector3 moveDirection;

    [SerializeField] private Transform target;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        CameraBounds();
    }
    
    private void Inputs()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(horizontal, vertical).normalized;
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void CameraBounds()
    {
        if (transform.position.x > 5f)
        {
            transform.position = new Vector3(5f, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -5f)
        {
            transform.position = new Vector3(-5f, transform.position.y, transform.position.z);
        }

        if (transform.position.y > 5f)
        {
            transform.position = new Vector3(transform.position.x, 5f, transform.position.z);
        }

        if (transform.position.y < 1f)
        {
            transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
        }
    }

}
