////////////////////////////
/// By: Gavin C
/// Date: 11/4/2020
/// Desription: This is the simple player controller, controls horizontal and vertical movement
///////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("The horizontal movement speed of the character.")]
    public float MovementSpeed = 5;
    [Tooltip("The force the player will jump with.")]
    public float JumpForce = 5;
    [Tooltip("The child object that is the hitbox for the feet.")]
    public GameObject Feet;
    [Tooltip("The radius around the feet that checks for the ground.")]
    public float CheckRadiusSize = 0.3f;
    [Tooltip("The type of object that counts as ground.")]
    public LayerMask GroundType;
    Rigidbody2D RB;
    bool IsGrounded;



    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Changes the players horizontal movement
        RB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * MovementSpeed, RB.velocity.y);

        //Flip character
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }


        //Check if the object is on the ground
        IsGrounded = Physics2D.OverlapCircle(Feet.GetComponent<Transform>().position, CheckRadiusSize, GroundType);

        //Apply velocity if grounded and space down
        if (IsGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            RB.velocity = Vector2.up * JumpForce;

        }
    }
}
