using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSettings : MonoBehaviour
{
    [SerializeField] [Tooltip("Put prefab that rope is made up of")] GameObject ropePartPrefab, parentObject;

    [Tooltip("Sets the length of the spawned rope")]int length = 2; // rope length

    [SerializeField] private float ropePartDistance = 0.21f;

    [SerializeField] private bool reset, snapFirst;


    private void Awake()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        //Looks for the current temporary objects in the game, to then remove them in the scene
        if (reset)
        {
            //if there's objects with correct tag within the scene
            if (GameObject.FindGameObjectsWithTag("RopePart") != null)
            {
                foreach (GameObject tempObject in GameObject.FindGameObjectsWithTag("RopePart"))
                {
                    //NOTE: IF the project was using a object pooler, we would simply deactivate instead
                    Destroy(tempObject); //remove objects
                }
            }
            else
            {
                //if no objects are in the scene trigger a warning
                Debug.LogWarning("There are no rope parts within the current play space, please make sure to spawn some.");
            }
        }
    }

    //NOTE: IF this was a more extensive product, we could pull the spawning into an object pooler for better performance handling rather than creating trash from destroying and spawning more.
    //Handles the spawning of the parts of the rope and applying the joints to each newly spawned component.
    public void Spawn()
    {
        int count = (int)(length / ropePartDistance);

        for (int i = 0; i < count; i++)
        {
            GameObject tempObject; // temporary object 

            //spawning object at correct locations
            tempObject = Instantiate(ropePartPrefab, new Vector3(transform.position.x, transform.position.y + ropePartDistance * (i + 1), transform.position.z), Quaternion.identity, parentObject.transform);
            tempObject.transform.eulerAngles = new Vector3(180, 0, 0);

            //assigning a name to the temporary object 
            tempObject.name = parentObject.transform.childCount.ToString();

            
            //checks if the current iteration is 0
            if (i == 0)
            {
                //if iteration is 0 then destroy the temporary objects character joint component
                Destroy(tempObject.GetComponent<HingeJoint>());

                //Freezes first rope part
                if (snapFirst)
                {
                    tempObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                }
            }
            else
            {
                //otherwise apply the character joint to connect with ther next closest rigidbody
                tempObject.GetComponent<HingeJoint>().connectedBody = parentObject.transform.Find((parentObject.transform.childCount - 1).ToString()).GetComponent<Rigidbody>();
            }
        }   
    }
}
