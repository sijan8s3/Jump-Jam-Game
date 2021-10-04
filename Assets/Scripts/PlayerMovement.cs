using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;

    private Animator anim;
    private SpriteRenderer sprite;
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState
    {
        idle,
        running,
        jumping,
        falling
    }

    private void Start()
    {
        //extending the RigidBody
        rigidBody = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();

        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //get direction: if pressed left (-1), if right (+1)
        dirX = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(dirX * moveSpeed, rigidBody.velocity.y);

        //when we press space key down (not hold)
        if (Input.GetButtonDown("Jump") && IsGrounded()) 
        {

            //change the velocity of object
            // Vector3 just a dataholder for 3 values X, Y & Z
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, jumpForce, 0);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState _state;
        
        //running forward
        if (dirX > 0f)
        {
            _state = MovementState.running;
            sprite.flipX = false;
        }
        //running backward
        else if (dirX < 0f)
        {
            _state = MovementState.running;
            sprite.flipX = true;
        }
        //not running
        else
        {
            _state = MovementState.idle;
        }

        if (rigidBody.velocity.y > 0.1f)
        {
            _state = MovementState.jumping;
        }
        else if (rigidBody.velocity.y < -0.1f)
        {
            _state = MovementState.falling;
        }

        anim.SetInteger("state", (int)_state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
