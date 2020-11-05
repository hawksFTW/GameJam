//////////////////////////////////////////
//By: Gavin C
//Date: 10/20/20
//Description: A camera script that can make the camera follow using linear interpolation
//////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //initializing variables
    [Tooltip("The object the camera will follow.")]
    public GameObject Target;
    [Tooltip("This should be between 0 and 1 based on how quick you want the camera to snap to the object.")]
    public float Smoothing = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Target != null)
        {
            //retrive and save position of target
            Vector3 newPos = Target.transform.position;
            //adjust the z value back to the camera's normal height
            newPos.z = transform.position.z;
            //linear interpolate towards the target
            transform.position = Vector3.Lerp(transform.position, newPos, Smoothing);
        }
    }
}
