using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform one;
    public Transform two;
   public float velocity = 3f;
    Animator anim;
    public bool goTwo = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
        
    }
    private void Update()
    {
        if (!goTwo)
        {
            transform.position = Vector2.MoveTowards(transform.position, two.position, velocity * Time.deltaTime);
            if (transform.position.y == two.position.y)
            {
                goTwo = true;
            }

        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, one.position, velocity * Time.deltaTime);

            if (transform.position.y == one.position.y)
            {

                goTwo = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
