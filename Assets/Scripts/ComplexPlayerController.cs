////////////////////////////
/// By: Gavin C
/// Date: 11/4/2020
/// Desription: This is the more complex player controller allowing for higher jumps if space is held
/// Help From: https://www.youtube.com/watch?v=j111eKN8sJw
///////////////////////////

using Packages.Rider.Editor.PostProcessors;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ComplexPlayerController : MonoBehaviour
{
    [Tooltip("The horizontal movement speed of the character.")]
    public float MovementSpeed = 5;
    [Tooltip("The force the player will jump with.")]
    public float JumpForce = 10;
    [Tooltip("The child object that is the hitbox for the feet.")]
    public GameObject Feet;
    [Tooltip("The radius around the feet that checks for the ground.")]
    public float CheckRadiusSize = 0.3f;
    [Tooltip("The type of object that counts as ground.")]
    public LayerMask GroundType;
    [Tooltip("The amount of time you can hold down space to jump higher.")]
    public float JumpTime = 1;
    Rigidbody2D RB;
    bool IsGrounded;
    bool IsJumping = false;
    float JumpTimeCounter = 0;


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

        //Flip character when moving
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

        //Apply velocity if grounded and space down, also set up JumpTimer and IsJump
        if (IsGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            RB.velocity = new Vector2(RB.velocity.x, Vector2.up.y * JumpForce);
            JumpTimeCounter = 0;
            IsJumping = true;
        }

        //Let the player keep jumping if they havent let up the space bar
        if (Input.GetKey(KeyCode.Space) && IsJumping == true)
        {   
            //Lets you keep jumping if time hasn't run out
            if (JumpTimeCounter < JumpTime)
            {
                RB.velocity = new Vector2(RB.velocity.x, Vector2.up.y * JumpForce);
                JumpTimeCounter += Time.deltaTime;
            }
            else
            {   
                IsJumping = false;
            }
        }

        //Prevent higher jump when space is stopped being pressed
        if(Input.GetKeyUp(KeyCode.Space))
        {
            IsJumping = false;
        }
    }
}
