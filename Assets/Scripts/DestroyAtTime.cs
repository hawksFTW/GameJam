////////////////////////////
/// By: Gavin C
/// Date: 11/4/2020
/// Desription: This is a script that destoys the object after some amount of time
///////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAtTime : MonoBehaviour
{
    [Tooltip("The amount of time before it destroys itself.")]
    public float Time = 1;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, Time);
    }
}
