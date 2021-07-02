using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Animator anim;
    private SpriteRenderer sprite;
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    // Start is called before the first frame update
    private void Start()
    {
        //extending the RigidBody
        rigidBody = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        //get direction: if pressed left (-1), if right (+1)
        dirX = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(dirX * moveSpeed, rigidBody.velocity.y);

        //when we press space key down (not hold)
        if (Input.GetButtonDown("Jump")) 
        {

            //change the velocity of object
            // Vector3 just a dataholder for 3 values X, Y & Z
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, jumpForce, 0);
        }

        UpdateAnimationState();

        
    }

    private void UpdateAnimationState()
    {
        //running forward
        if (dirX > 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;

        }
        //running backward
        else if (dirX < 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        //not running
        else
        {
            anim.SetBool("running", false);
        }
    }


}
