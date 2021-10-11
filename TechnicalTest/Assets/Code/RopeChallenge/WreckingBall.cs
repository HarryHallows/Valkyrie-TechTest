using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBall : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    private Vector3 targetPosition;


    // Start is called before the first frame update
    void Start()
    {
        targetObject = GameObject.Find("RopeParts");
    }

    // Update is called once per frame
    void Update()
    {
        if (targetObject != null)
        {
            FindParent();
            WreckingBallPosition();
        }
    }

    private void FindParent()
    {
        for (int i = 0; i < targetObject.transform.childCount; i++)
        {
            int lastChild = targetObject.transform.childCount - 1;
            targetPosition = targetObject.transform.GetChild(lastChild).position;
        }
        
    }

    private void WreckingBallPosition()
    {
        gameObject.transform.position = targetPosition;
    }
}
