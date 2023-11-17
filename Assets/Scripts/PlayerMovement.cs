using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class playerMovement : MonoBehaviour
{
    // get a reference to the classes
    private Rigidbody2D rigidBody;
    private Animator anim;
    private SpriteRenderer playerSprite;
    private BoxCollider2D boxCollider;

    [SerializeField] private LayerMask ground; 

    private const float horizontalSpeed = 7.0f;
    private const float jumpSpeed = 750.0f;
    private float xDirection;

    private enum MovementState { idle, running, jumping, falling } // enum for player movement

    [SerializeField] private AudioSource jumpingAudio; // reference to audio source in editor

    // Start is called before the first frame update
    private void Start()
    {
        // assign instances so functions are not constantly re-called

        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        xDirection = Input.GetAxisRaw("Horizontal"); // use input axis to get the player's x direction
        rigidBody.velocity = new Vector2(xDirection * horizontalSpeed, rigidBody.velocity.y); // make the player move left/right


        if (Input.GetKeyDown("up") && PlayerOnGround()) // check if space bar is pressed
        {
            jumpingAudio.Play();
            rigidBody.AddForce(transform.up * jumpSpeed); // use input axis to make the player jump
        }

        UpdateAnimationState();

    }

    private void UpdateAnimationState()
    {
        MovementState mMovementState; // create instance of enum

        //switch (xDirection)
        //{
        //    case > 0:
        //        mMovementState = MovementState.running;
        //        playerSprite.flipX = false;
        //        break;

        //    case < 0:
        //        mMovementState = MovementState.running;
        //        playerSprite.flipX = true;
        //        break;

        //    case 0:
        //        mMovementState = MovementState.idle;
        //        break;
        //}

        //switch (rigidBody.velocity.y)
        //{
        //    case > 0.05f:
        //        mMovementState = MovementState.jumping;
        //        break;

        //    case < -0.05f:
        //        mMovementState = MovementState.falling;
        //        break;
        //}

        // check the value of the player's x direction and change the movement state and left/right position based on this

        if (xDirection > 0)
        {
            mMovementState = MovementState.running;
            playerSprite.flipX = false; // player is facing right
        }

        else if (xDirection < 0)
        {
            mMovementState = MovementState.running;
            playerSprite.flipX = true; // player is facing left
        }

        else
        {
            mMovementState = MovementState.idle;

        }

        // check check the value of the player's y direction and change the movement state based on this

        if ( rigidBody.velocity.y > 0.05f)
        {
            mMovementState = MovementState.jumping;
        }

        else if (rigidBody.velocity.y < -0.05f)
        {
            mMovementState = MovementState.falling;
        }

        anim.SetInteger("movementState", (int)mMovementState); // set the animation index (0,1,2,3) based on the movement state
    }

    private bool PlayerOnGround() // function to make sure player can only jump when touching the floor and not mid-air
    {
        // return true if player is touching the ground by using box collider 
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, ground);
    }
} 

