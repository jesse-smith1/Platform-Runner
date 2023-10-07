using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  
      //making variable accessible throughout the full script.
      //private only allows variable to be used in this script.
      //making a variable call rb givin it the value of RigidBody2D component.
      private Rigidbody2D rb;
      //making a vairable called anim - value === Animator Component.
      private Animator anim;
      //this enables your picture to be seen the other way around.
      private SpriteRenderer sprite;
      //---Character Actions---//
      private float dirX = 0f;
      // [SerielizeField] = expose to editor so you are able to edit it through unity
      [SerializeField] private float moveSpeed = 3f;
      [SerializeField] private float jumpForce = 6f;

      [SerializeField] private LayerMask jumpableGround;
      //Boxcollider for jump
      private BoxCollider2D coll;

      private enum MovementState { idle, running, jumping, falling }
     
    //values get converted to int values
    // Start is called before the first frame update
    private void Start()
    {
      //setting variable name coll to give it a value
      coll = GetComponent<BoxCollider2D>();
      //rb has been assigned the value of Getting the Component of 
      //Rigidbody2D componenet.
      rb = GetComponent<Rigidbody2D>();
      //; used when you want the function to finish executing?
      //getting the component Animator to enable animations
      anim = GetComponent<Animator>();
      //referencing the SPrite Renderer (will enable you to see picture from other side)
      sprite = GetComponent<SpriteRenderer>();
    }
 // Update is called once per frame
    private void Update()
    {
      //float because we are using a decimal number along the x axis
      dirX = Input.GetAxis("Horizontal");
      //Changing the velocity giving its values x axis * 3f(float number), with another axis of rigidbody2D
      //velocity of the y axis.
      rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y );
      //conditional if "space bar is used" (we changed it from space to the buttons used in game "Jump").
        if (Input.GetButtonDown("Jump") && IsGrounded())
        //then this happens
        {
          //get this component that is called <Rigidboy2D> = variable name that takes 3 data place values
          //x y and z 
         rb.velocity = new Vector3(rb.velocity.x, jumpForce);
        }
        UpdateAnimationState();
    }
    //seperating into other methods
    //void means it executes the function without a return
     private void UpdateAnimationState()
    {
      MovementState state;
        //if horizontal axis more than 0f (float value), player moves right
        if (dirX > 0f)
        {
          //using Animator to set a boolean of "Running" - of named parameter.
        state = MovementState.running;
        sprite.flipX = false;
        }
        // if horizontal axis is less than 0f - player is moving left
        else if (dirX < 0f)
        {
          //state = enum MovementState that uses the actions we have given it, 
          state = MovementState.running;
          sprite.flipX = true;
        }
        else 
        {
          state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
          state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
          state = MovementState.falling;
        }
        //setting an integer value to state. (int)state)
          anim.SetInteger("state",(int)state);
    }
    private bool IsGrounded()
    {
     return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround );
    }
}
