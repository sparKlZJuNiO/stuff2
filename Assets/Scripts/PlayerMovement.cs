using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;    // Constant forward speed
    public float jumpForce = 10f;   // Jump force
    public Transform groundCheckPoint;  // A point to check if the player is grounded
    public float checkRadius = 0.2f;   // Radius of the overlap circle for ground detection
    public LayerMask groundLayer;     // Layer of the ground objects

    private Rigidbody2D rb;        // Reference to the Rigidbody2D component
    private bool isGrounded;     // Is the player on the ground?

    public AudioClip jump;
    public AudioClip backgroundMusic;

    public AudioSource sfxPlayer;
    public AudioSource musicPlayer;

    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the RigidBody2D component attached to the player
        musicPlayer.clip = backgroundMusic;
        musicPlayer.loop = true;
        musicPlayer.Play();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Constant forward movement 
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, checkRadius,groundLayer);

        anim.SetBool("IsOnGround", isGrounded);


        // Jumping logic
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

    }

    private void Jump()
    {
        // Add an upward force for jumping
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        sfxPlayer.PlayOneShot(jump);
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a circle to visualize the ground check point in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckPoint.position, checkRadius);
    }
}
