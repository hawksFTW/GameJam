//////////////////////////////////////////
//By: Gavin C
//Date: 11/8/20
//Description: Script to be used by unity event that moves the object
//////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EventMoveObject : MonoBehaviour
{   
    [Tooltip("The location the object will move to.")]
    public Vector3 NewPosition;

    //Function to be called that changes the position of the door
    public void MoveObject()
    {
        transform.position = NewPosition;
    }
}
