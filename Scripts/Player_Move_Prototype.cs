using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Prototype : MonoBehaviour{

    public int playerspeed = 10;
    public int playerJumpPower = 500;
    private float moveX;
    public bool isGrounded;
    public float distanceToBottomOfPlayer = 0.9f;

    // Update is called once per frame
    void Update(){
        PlayerMove();
        PlayerRaycast();
    }

    void PlayerMove()
    {
        //Controls
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown ("Jump") && isGrounded == true)
        {
        //    SoundManagerScript.PlaySound("jump");
            Jump();
        }

        //Animations
        //if (moveX != 0)
        //{
        //    GetComponent<Animation>().SetBool("IsRunning", true);
        //} else
        //{
        //    GetComponent<Animation>().SetBool("IsRunning", false);
        //}

        //Player Directions
        if (moveX < 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        } else if (moveX > 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;

        }


        //Physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerspeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }


    void Jump()
    {
        //Jumping Code 
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
        isGrounded = false;


    }

    private void PlayerRaycast()
    {
        //rayUP
        RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up);
        if (true && rayUp.collider != null && rayUp.distance < distanceToBottomOfPlayer && rayUp.collider.name == "Question") {

            Destroy(rayUp.collider.gameObject);

    }
        //rayDown
        RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down);
        if (true && rayDown.collider != null && rayDown.distance < distanceToBottomOfPlayer && rayDown.collider.tag == "enemy")
        {//careful with the val of additional jump 
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 400);
            Destroy(rayDown.collider.gameObject);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 10;
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            rayDown.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rayDown.collider.gameObject.GetComponent<EnemyMove>().enabled = false;

        }

        if (true && rayDown.collider != null && rayDown.distance < 0.9f && rayDown.collider.tag != "enemy")
        {
            isGrounded = true;
        }
    }


}
