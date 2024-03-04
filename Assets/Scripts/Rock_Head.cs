using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Head : MonoBehaviour
{
    public Transform one;
    public Transform two;
    public Transform three;
    public Transform four;
    public float velocity = 10f;
   
    public bool goTwo = true;
    public bool goFour = true;

    private void Update()
    {


        if (!goTwo&& !goFour )
        {
            transform.position = Vector2.MoveTowards(transform.position, two.position, velocity * Time.deltaTime);
            if (transform.position.x == two.position.x&& transform.position.y == two.position.y)
            {
                goTwo = true;
                goFour = false;
                
               

            }

        }
        if(goTwo && !goFour)
        {
            transform.position = Vector2.MoveTowards(transform.position, three.position, velocity * Time.deltaTime);

            if (transform.position.x == three.position.x&& transform.position.y == three.position.y)
            {
                
                goTwo = true;
                goFour = true;
            }
               
        }
        if (goTwo && goFour)
        {
            transform.position = Vector2.MoveTowards(transform.position, four.position, velocity * Time.deltaTime);

            if (transform.position.x == four.position.x&& transform.position.y == four.position.y)
            {
                
                goTwo = false;
                goFour = true;
            }

        }
        if (!goTwo && goFour)
        {
            transform.position = Vector2.MoveTowards(transform.position, one.position, velocity * Time.deltaTime);

            if (transform.position.x == one.position.x&& transform.position.y == one.position.y)
            {
                
                goTwo = false;
                goFour = false;
            }

        }



    }
}
