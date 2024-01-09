using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float horizontalInput;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        
        horizontalInput = Input.GetAxis("Horizontal");

        Vector3 vector3 = new Vector3(horizontalInput,0,0);
        rb.AddForce(vector3 * speed);

       if(Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().velocity=new Vector3(0,7,0);
        }
    }
}
