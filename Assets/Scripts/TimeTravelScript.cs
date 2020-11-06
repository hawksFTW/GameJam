////////////////////////////
/// By: Nathan
/// Date: 11/4/2020
/// Desription: This is script teleports the player and camera some distance away, "could" be accessed though another object
///////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravelScript : MonoBehaviour
{
    [Tooltip("How Far the player is teleported in x y and z")]
    public Vector3 offset = Vector3.zero;
    [Tooltip("The GameObject to summon that plays the time travel sound.")]
    public GameObject TimeTravelSound;

    private bool Pressed = false;
    private bool Present = true;


    // Start is called before the first frame update
    void Update()
    {
        TimeTravel();
    }

    // Update is called once per frame
    public void TimeTravel()
    {
        if(Input.GetAxisRaw("Fire1") > 0)
        {
            if(Pressed == false)
            {
                Pressed = true;
                if(Present == true)
                {
                    transform.position += offset;
                    Camera.main.transform.position += offset;
                    Present = false;
                }
                else if(Present == false)
                {
                    transform.position -= offset;
                    Camera.main.transform.position -= offset;
                    Present = true;
                }

                //this will telleport the camera to the players position even if it isnt currently on the players position.
                //Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);

                //Summon time travel sound player
                Instantiate<GameObject>(TimeTravelSound, transform.position, transform.rotation);
            }
        }
        else
        {
            Pressed = false;
        }
    }
}