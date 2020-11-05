////////////////////////////
/// By: Gavin C
/// Date: 11/4/2020
/// Desription: This is the more complex player controller allowing for higher jumps if space is held, you need to add an object that is the feet of the player, you also need to add an audio source
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
    [Tooltip("The GameObject to summon that plays the jump sound.")]
    public GameObject JumpSound;
    Rigidbody2D RB;
    int Dirrection = 0;
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
        //Figure out the dirrection
        if(Input.GetKeyDown("a"))
        {
            Dirrection = -1;
        }
        if(Input.GetKeyDown("d"))
        {
            Dirrection = 1;
        }
        if(Input.GetKey("d") == false && Input.GetKey("a") == false)
        {
            Dirrection = 0;
        }


        //Changes the players horizontal movement
        RB.velocity = new Vector2(Dirrection * MovementSpeed, RB.velocity.y);

        //Flip character when moving
        if (Dirrection > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Dirrection < 0)
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

            //Summon jump sound player
            Instantiate<GameObject>(JumpSound, transform.position, transform.rotation);
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
