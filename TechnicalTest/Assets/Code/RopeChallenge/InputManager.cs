using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.mousePosition);
        MouseInput();
    }

    private void MouseInput()
    {
        //Debug.Log(mainCamera.ScreenToWorldPoint(Input.mousePosition));

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(cameraRay, out hit))
        {
            transform.position = hit.point;

            if (hit.collider.tag == "WreckingBall" && Input.GetMouseButton(0))
            {
                Debug.Log("Hitting ball with mouse");

                GameObject ball = hit.transform.gameObject;

                Debug.Log(ball.name);

                BallDrag(ball);
            }
        }

        //transform.position = mouseWorldPosition;
    }

    private void BallDrag(GameObject ball)
    {
        Vector2 mousePosition = new Vector2(transform.position.x, transform.position.y);
        ball.transform.position = mousePosition;
    }
}
