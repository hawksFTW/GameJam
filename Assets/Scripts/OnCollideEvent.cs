//////////////////////////////////////////
//By: Gavin C
//Date: 11/8/20
//Description: Script that invokes events on collision with non eviornment objects
//////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCollideEvent : MonoBehaviour
{
    [Tooltip("Events to be run when object collides.")]
    public UnityEvent OnCollide;

    //on collide with something other than the environment, invoke all events
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Transform>().tag != "Environment")
        {
            OnCollide.Invoke();
        }
    }
}
