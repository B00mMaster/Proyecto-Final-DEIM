using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform one;
    public Transform two;
    public float velocity = 3f;
    public bool goTwo = true;

    private void Update()
    {
        if (!goTwo)
        {
            //the platform will move point to point constantly
            transform.position = Vector2.MoveTowards(transform.position, two.position, velocity * Time.deltaTime);
            if (transform.position.y == two.position.y && transform.position.x == two.position.x)
            {
                goTwo = true;
            }

        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, one.position, velocity * Time.deltaTime);

            if (transform.position.y == one.position.y && transform.position.x == one.position.x)
            {

                goTwo = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            //Parent the player to the platform when they collide
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
