using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Apple_colision : MonoBehaviour
{
    public string NextScene;
    public GameObject[] apples;
    int applesTaken;
    public TextMeshProUGUI counter;

    private void Start()
    {
        counter.text = "0/6";
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("apple"))
        {
            Destroy(collision.gameObject);

            applesTaken++;

            counter.text=applesTaken+"/6";
        }
        if(collision.gameObject.CompareTag("Finish"))
        {

            Invoke("ToNextScene", 2f);
               
            
        }
        if (applesTaken < 6 && collision.gameObject.CompareTag("Finish"))
        {
            counter.text = "You must collect all apples!";
        }
    }

    void ToNextScene()
    {
        SceneManager.LoadScene(NextScene);
    }

}
