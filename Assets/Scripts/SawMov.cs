using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMov : MonoBehaviour
{
    public Transform one;
    public Transform two;
    public float velocity = 3f;
    
    public bool goTwo = true;

   
    
    private void Update()
    {
        if (!goTwo)
        {
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
}
