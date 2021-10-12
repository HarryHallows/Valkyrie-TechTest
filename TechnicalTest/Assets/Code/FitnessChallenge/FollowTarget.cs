using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform cameraPosition;

    [SerializeField] private bool cameraTarget = false;

    // Start is called before the first frame update
    void Start()
    {
        //Could also set the component reference here, however if the developer wants the option to toggle on and off this will only call once at start
    }

    // Update is called once per frame
    void Update()
    {
        //If we wanted to expand this class to have multiple follow functionality
        if (cameraPosition == null)
        {
            if (cameraTarget)
            {
                //Gets transform of the camera gameobject in the scene 
                cameraPosition = GameObject.Find("Main Camera").transform;
            }
        }
        else
        {
            SettingPosition();
        }
    }

    private void SettingPosition()
    {
        //constantly sets this object to the position of Camera Position
        transform.position = cameraPosition.position;
    }
}
