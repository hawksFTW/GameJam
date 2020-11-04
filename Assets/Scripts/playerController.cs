//By: Dhruv
//Date: 11/4/2020
//Description: Simple script for 4 directional movement with forces 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [Tooltip("This is how fast the player can go forward and back")]
    public float Speed = 200;

    //[Tooltip("This is how fast we turn")]
    //public float AngularSpeed = 10;
    Rigidbody2D myRb;
    // Start is called before the first frame update
    void Start()
    {
        //find the rigidbody of the game object
        myRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2();

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Add torque to spin based on controls
        //myRb.AddTorque(-AngularSpeed * movement.x * Time.deltaTime);

        myRb.AddForce(movement * Speed * Time.deltaTime);
    }
}