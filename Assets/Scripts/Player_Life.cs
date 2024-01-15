using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Life : MonoBehaviour
{

    private Animator anim;
    private Rigidbody rb;

    private void Start()
    {
        anim= GetComponent<Animator>();
        rb= GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
           if(collision.gameObject.CompareTag("spikes"))
        {
            anim.SetTrigger("death");
            
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
