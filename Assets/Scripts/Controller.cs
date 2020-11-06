// Jackson Neal
// 11.5.2020
// Desription: Make player move
// Credit: https://www.youtube.com/watch?v=j111eKN8sJw

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;
    private float moveInput;
    public float jumpForce;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatisGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatisGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
}