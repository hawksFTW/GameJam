////////////////////////////
/// By: Gavin C
/// Date: 11/4/2020
/// Desription: This is a script activates the TimeTravel function on the player object
///////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravelButton : MonoBehaviour
{   
    //Function to be called on by unity event
    public void TimeTravel()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<TimeTravelScript>().TimeTravel();
    }
}
