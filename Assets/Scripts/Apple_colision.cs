using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Apple_colision : MonoBehaviour
{
    public string NextScene;
    Animator anim;
    private Rigidbody rb;
    public ParticleSystem particle;
    public int applesTaken;
    public TextMeshProUGUI counter;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(counter!=null)
        {
            counter.text = "Apples:0/6";
        }
            
        anim = GetComponent<Animator>();

        particle.Stop();
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("apple"))
        {
            Destroy(collision.gameObject);

            applesTaken++;

            counter.text="Apples:"+applesTaken+"/6";
        }
        if(applesTaken>5)
        {
            particle.Play();
        }
        if(applesTaken >5 &&  collision.gameObject.CompareTag("Finish"))
        {
           
            anim.SetTrigger("NextLevel");
            Invoke("ToNextScene", 1f);
               
            
        }
        if(applesTaken< 5 && collision.gameObject.CompareTag("Finish"))
        {
            counter.text = "You must collect all apples!";
        }
    }

    void ToNextScene()
    {
        SceneManager.LoadScene(NextScene);
    }

}
