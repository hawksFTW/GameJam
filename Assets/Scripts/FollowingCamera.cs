//////////////////////////////////////////
//By: Gavin C
//Date: 10/20/20
//Description: A camera script that can make the camera follow using linear interpolation
//////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    //initializing variables
    [Tooltip("The object the camera will follow.")]
    public GameObject Target;
    [Tooltip("The offset of the camera compared to the location of the player.")]
    public Vector2 OffSet;
    [Tooltip("This should be between 0 and 1 based on how quick you want the camera to snap to the object.")]
    public float Smoothing = 0.1f;
    [Tooltip("Should the camera start on the object.")]
    public bool CameraStartOn = true;

    // Start is called before the first frame update
    void Start()   
    {
        //move camera ontop of player at start if needed
        if (CameraStartOn == true)
        {
            transform.position = new Vector3(Target.GetComponent<Transform>().position.x + OffSet.x, Target.GetComponent<Transform>().position.y + OffSet.y, transform.position.z);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Target != null)
        {
            //retrive and save position of target
            Vector3 newPos = new Vector3(Target.transform.position.x + OffSet.x, Target.transform.position.y + OffSet.y, transform.position.z);
            //linear interpolate towards the target
            transform.position = Vector3.Lerp(transform.position, newPos, Smoothing);
        }
    }
}
