using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_Head : MonoBehaviour
{
    public Transform one;
    public Transform two;
     float velocity=3f;
    Animator anim;
    public bool goTwo = true;
    private void Update()
    {


        if (!goTwo)
        {
            transform.position = Vector2.MoveTowards(transform.position, two.position, velocity * Time.deltaTime);
            if (transform.position.x == two.position.x)
            {
                goTwo = true;
                velocity = 5f;
                anim.SetBool("hit", true);
            }

        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, one.position, velocity * Time.deltaTime);

            if (transform.position.x == one.position.x)
            {
                velocity = 10f;
                goTwo = false;
                anim.SetBool("hit", false);
            }
        }
        
           
        
    }
    
}
