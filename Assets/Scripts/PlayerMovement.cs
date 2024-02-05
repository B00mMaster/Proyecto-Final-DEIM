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
    public float jumpsLeft=2;
    public bool isGround;
    
    private enum Movement { iddle,running,jumping,falling};

    public float distanceRay;
    public float distanceRay2;
    public LayerMask ground;
    public LayerMask roof;
    
    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        
    }
    void Update()
    {
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up, distanceRay,  roof);
        
       // RaycastHit2D isGrounded = Physics2D.Raycast(transform.position, Vector2.down,distanceRay2, ground);
        RaycastHit2D isGroundedR = Physics2D.Raycast(transform.position, Vector2.right, distanceRay2, ground);
        RaycastHit2D isGroundedL = Physics2D.Raycast(transform.position, Vector2.left, distanceRay2, ground);

        if (hitUp.collider!=null&&Input.GetKey(KeyCode.UpArrow))
        {
           //Debug.Log("Tocando TEcho");
            rb.gravityScale = -1f;
            jumpsLeft = 2;
            isGround = true;
            sprite.flipY = true;
        }
        else if (hitUp.collider != null || hitUp.collider == null)
            {
                //Debug.Log("gravity again");
                rb.gravityScale = 3f;
            
            
            sprite.flipY = false;
        }

        
        Movement state;
        
        horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        //Debug.Log(isGrounded!);

       
        if (isGroundedL.collider != null && Input.GetKeyDown(KeyCode.UpArrow) || Input.GetButtonDown("Salto"))
        {
            Debug.Log("JUMPING");
            Jump();
            jumpsLeft = 2;
            isGround = true;
        }
        if (isGroundedR.collider != null && Input.GetKeyDown(KeyCode.UpArrow) || Input.GetButtonDown("Salto"))
        {
            Debug.Log("JUMPING");
            Jump();
            jumpsLeft = 2;
            isGround = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && (isGround && jumpsLeft > 0) || Input.GetButtonDown("Salto"))
        {
            Jump();
        }
        if (jumpsLeft == 0 && isGround == true)
        {
            jumpsLeft = 2;
        }

        //Debug.DrawRay(transform.position, Vector2.down, Color.blue, distanceRay2);


        if (horizontalInput >0f) 
        {
            state = Movement.running;
            sprite.flipX = false;
        }
        else if (horizontalInput < 0f)
        {
            state = Movement.running;
            sprite.flipX=true;
        }
        else  
        {
            state = Movement.iddle;
        }

        if(rb.velocity.y>.1f)
        {
            state = Movement.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = Movement.falling;
        }

        anim.SetInteger("state",(int)state);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpsLeft--;

        if (!isGround)
        {
            jumpsLeft = 2;
        }
        if (jumpsLeft == 0)
        {
            isGround= false;

        }


    }

    void OnCollisionEnter2D(Collision2D collision)
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
