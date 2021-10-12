using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitnessController : MonoBehaviour
{
    //Character Animator
    [SerializeField] private Animator anim;
    
    [SerializeField] [Tooltip("The animation conditions")]private bool idle, fight, dance;
    // Start is called before the first frame update
    void Awake()
    {
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
     
    }
}
