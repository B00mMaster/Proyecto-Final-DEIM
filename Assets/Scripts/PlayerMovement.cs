using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce;
    public float speed;
    public float horizontalInput;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    public float jumpsLeft=2;
    public bool isGround;
    
    

    public float distanceRay;
    public float distanceRay2;
    public LayerMask ground;
    public LayerMask roof;

    private Player_Life playerLife;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        playerLife = GetComponent<Player_Life>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        
    }
    void Update()
    {
        if (playerLife.IsDead())
        {
            
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            return;
        }
        
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up, distanceRay, ground);

        // RaycastHit2D isGrounded = Physics2D.Raycast(transform.position, Vector2.down,distanceRay2, ground);
        //RaycastHit2D isGroundedR = Physics2D.Raycast(transform.position, Vector2.right, distanceRay2, ground);
        //RaycastHit2D isGroundedL = Physics2D.Raycast(transform.position, Vector2.left, distanceRay2, ground);

        if (hitUp.collider != null && Input.GetKey(KeyCode.UpArrow))
        {
            //Debug.Log("Tocando TEcho");
            rb.gravityScale = -1f;

            state = 4;
            sprite.flipY = true;
        }
        else if (hitUp.collider != null || hitUp.collider == null)
        {
            //Debug.Log("gravity again");
            rb.gravityScale = 3f;
            


            sprite.flipY = false;
        }


        int state = 0;

        horizontalInput = Input.GetAxis("Horizontal");


        // //Debug.Log(isGrounded!);


        //if (isGroundedL.collider != null && Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    Debug.Log("JUMPING");
        //    //**Jump();
        //    //**jumpsLeft = 2;
        //    //**isGround = true;
        //}
        //if (isGroundedR.collider != null && Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    Debug.Log("JUMPING");
        //    //**Jump();
        //    //**jumpsLeft = 2;
        //    //**isGround = true;
        //}
        if (Input.GetKeyDown(KeyCode.UpArrow) && (isGround || jumpsLeft > 0))
        {
            Jump();
        }



        //Debug.DrawRay(transform.position, Vector2.down, Color.blue, distanceRay2);


        if (horizontalInput > 0f)
        {
            state = 1;

            sprite.flipX = false;
        }
        else if (horizontalInput < 0f)
        {
            state = 1;
             
            sprite.flipX = true;
        }
        else
        {
            state = 0;

        }

        if (rb.velocity.y > .1f)
        {
            state = 2;

        }
        else if (rb.velocity.y < -.1f)
        {
            state = 3;

        }
        //mamahuebo
        anim.SetInteger("state", state);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpsLeft--;
        isGround = false;

        //**if (isGround)
        //**{
        //**    jumpsLeft = 2;
        //**}
        //**if (jumpsLeft == 0)
        //**{
        //**    isGround= false;

        //**}


    }

    void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("ground"))
        {
            isGround = true;
            jumpsLeft = 2;


        }

    }


    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.up*distanceRay);
        
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, Vector2.down*distanceRay2);

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, Vector2.left * distanceRay2);

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, Vector2.right * distanceRay2);
    }

}
