using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    private void Start()
    {
        //extending the RigidBody
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //get direction: if pressed left (-1), if right (+1)
        float dirX = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(dirX * 7f, rigidBody.velocity.y);

        //when we press space key down (not hold)
        if (Input.GetButtonDown("Jump")) 
        {

            //change the velocity of object
            // Vector3 just a dataholder for 3 values X, Y & Z
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, 14f, 0);
        }
    }


}
