using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class FitnessController : MonoBehaviour
{
    //Character Animator
    [SerializeField] private Animator anim;

    //Reference for main camera to raycast
    [SerializeField] private Camera mainCamera;

    RaycastHit hit;
    [SerializeField] private LayerMask hitMask;

    [SerializeField] private GameObject handTarget;
    [SerializeField] TwoBoneIKConstraint handConstraint;
    [SerializeField] private Rig armRig;

    [SerializeField] [Tooltip("The animation conditions")]private bool idle, fight, dance;

    // Start is called before the first frame update
    void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        //References the character animator directly
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim != null)
        {
            Inputs();
        }
    }

    //If this was a more advanced demo I could've pulled this to it's own class and referenced it directly into the controller
    //Didn't feel needed though for such a small demo
    private void Inputs()
    {
        Animations();
    }

    private void Animations()
    {
        #region Idle
        if (Input.GetButton("Idle"))
        {
            if (!idle)
            {
                anim.SetTrigger("Idle");
                idle = true;
            }
        }
        else
        {
            idle = false;
        }
        #endregion

        #region Dance
        if (Input.GetButton("Dance"))
        {
            if (!dance)
            {
                anim.SetTrigger("Dance");
                dance = true;
            }
        }
        else
        {
            dance = false;
        }
        #endregion

        #region Fight
        if (Input.GetButton("Fight"))
        {
            Debug.Log("fight button down");

            if (!fight)
            {
                anim.SetTrigger("Fight");
                fight = true;
            }
        }
        else
        {
            fight = false;
        }
        #endregion

        #region Point
        if (Input.GetButton("Fire1"))
        {
            //anim.SetTrigger("Point");
            MousePointing();
        }
        else
        {
            armRig.weight = Mathf.MoveTowards(armRig.weight, 0, 1f * Time.deltaTime);
        }
   
        #endregion
    }

    private void MousePointing()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(cameraRay, out hit, hitMask))
        {
            handTarget.transform.position = hit.point;

            //Handles the handconstraint's rotation points based on the bounds of the mouse input
            IKRotations();
        }
        
    }

    private void IKRotations()
    {
        armRig.weight = Mathf.MoveTowards(armRig.weight, 1, 1f * Time.deltaTime);

        if (handTarget.transform.position.x > 0)
        {
            Vector3 desiredRotation = new Vector3(45f, 0f, handConstraint.transform.eulerAngles.z);
            handConstraint.transform.rotation = Quaternion.Euler(desiredRotation);
        }
        else if(handTarget.transform.position.y < 0)
        {
            Vector3 desiredRotation = new Vector3(0, 180f, handConstraint.transform.eulerAngles.z);
            handConstraint.transform.rotation = Quaternion.Euler(desiredRotation);
        }
    }
}
