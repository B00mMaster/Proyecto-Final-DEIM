using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float horizontalInput;
    Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {

        
        horizontalInput = Input.GetAxis("Horizontal");

        
        rb.velocity= new Vector2 (horizontalInput*speed,rb.velocity.y);

        if(Input.GetKeyDown("up"))
        {
           
            rb.velocity=new Vector3(0,10,0);
            anim.SetBool("jumping", true);
            anim.SetBool("running", false);
        }

        if(horizontalInput >0) 
        {
            anim.SetBool("jumping", false);
            anim.SetBool("running", true);
            sprite.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            anim.SetBool("jumping", false);
            anim.SetBool("running", true);
            sprite.flipX=true;
        }
        else  
        {
            anim.SetBool("jumping", false);
            anim.SetBool("running", false);
        }
    }
}
