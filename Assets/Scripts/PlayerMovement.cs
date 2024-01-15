using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce;
    public float speed;
    public float horizontalInput;
    Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    public int jumpsLeft;
    private bool isGrounded;
    private enum movement { iddle,running,jumping,falling};

    public float distanceRay = 1.0f;
    public LayerMask capaTecho;

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        jumpsLeft = 2;
    }
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, distanceRay,  capaTecho);

        if(hit.collider!=null&&Input.GetKey(KeyCode.UpArrow))
        {
           Debug.Log("Tocando TEcho");
            rb.gravityScale = -1f;
            sprite.flipY = true;
        }
        else if (hit.collider != null)
            {
                Debug.Log("gravity again");
                rb.gravityScale = 3f;
            sprite.flipY = false;
        }
        Debug.DrawRay(transform.position,Vector2.up,Color.red, distanceRay);

        if (jumpsLeft == 0 && isGrounded == true)
        {
            jumpsLeft = 2;
        }
        movement state;
        
        horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);



        if (Input.GetKeyDown("up")&&(isGrounded&&jumpsLeft>0))
        {
            Jump();
        }


        if(horizontalInput >0f) 
        {
            state = movement.running;
            sprite.flipX = false;
        }
        else if (horizontalInput < 0f)
        {
            state = movement.running;
            sprite.flipX=true;
        }
        else  
        {
            state = movement.iddle;
        }

        if(rb.velocity.y>.1f)
        {
            state = movement.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = movement.falling;
        }

        anim.SetInteger("state",(int)state);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpsLeft--;

        if (!isGrounded)
        {
            jumpsLeft = 2;
        }
        if(jumpsLeft==0)
        { 
            isGrounded = false;
        
        }
        
    }
   
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
            jumpsLeft = 2;


        }
        



    }

    

}
