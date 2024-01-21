using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple_colision : MonoBehaviour
{
    public GameObject[] apples;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("apple"))
        {
            Destroy(collision.gameObject);
        }
    }
}
