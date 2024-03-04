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
    public SoundManager soundManager;


    public float distanceRay;
    public float distanceRay2;
    public LayerMask ground;
   

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

        int state = 0;

        
        if (playerLife.IsDead())
        {
            //freeze player when dies
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            return;
        }
        
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up, distanceRay, ground);

       //rays for detecting collision player with the roof and walls
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, distanceRay2, ground);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, distanceRay2, ground);

        if (hitUp.collider != null && Input.GetKey(KeyCode.UpArrow))
        {
             state = 0;
          
            rb.gravityScale = -1f;
   
            sprite.flipY = true;
        }
        
        else if (hitUp.collider != null || hitUp.collider == null)
        {
            
            rb.gravityScale = 3f;

            

            sprite.flipY = false;
        }
        if(hitLeft.collider!= null && Input.GetKey(KeyCode.LeftArrow))
        {
            
            sprite.flipX = true;
            state = 4;
            jumpsLeft = 2;
            isGround = true;
        }
        if (hitRight.collider != null && Input.GetKey(KeyCode.RightArrow))
        {

            sprite.flipX = false;
            state = 4;
            jumpsLeft = 2;
            isGround = true;
        }



        horizontalInput = Input.GetAxis("Horizontal");


        
        if (Input.GetKeyDown(KeyCode.UpArrow) && (isGround || jumpsLeft > 0))
        {
            Jump();
            soundManager.SFX(soundManager.croak);
        }


        if (horizontalInput > 0f&& hitRight.collider == null)
        {
            state = 1;

            sprite.flipX = false;
        }
        else if (horizontalInput < 0f && hitLeft.collider == null)
        {
            state = 1;
             
            sprite.flipX = true;
        }
        
        if (rb.velocity.y > .1f)
        {
            state = 2;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = 3;
        }

        //each state num corresponds to one animation
        
        anim.SetInteger("state", state);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpsLeft--;
        isGround = false;

    }

  
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("ground"))
        {
            isGround = true;
            jumpsLeft = 2;


        }
        
    }

  //visualze rays
    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.up*distanceRay);
    
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, Vector2.left * distanceRay2);

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, Vector2.right * distanceRay2);
    }

}
