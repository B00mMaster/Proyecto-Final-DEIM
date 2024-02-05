using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Life : MonoBehaviour
{
   [SerializeField] public int deathCount=0;
    public TextMeshProUGUI deathCounter;
    private Animator anim;
    private Rigidbody rb;

    private void Start()
    {
        deathCount = PlayerPrefs.GetInt("DeathCount", 0);
        UpdateDeaths();
        anim= GetComponent<Animator>();
        rb= GetComponent<Rigidbody>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
           if(collision.gameObject.CompareTag("spikes"))
           {
            deathCount++;

            anim.SetTrigger("death");
           

            PlayerPrefs.SetInt("DeathCount",deathCount);
            PlayerPrefs.Save();
            
           }
    }

   void UpdateDeaths()
    {
        if(deathCounter!=null)
        {
            deathCounter.text = "Deaths:" + deathCount.ToString();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResetDeathCounter()
    {
        deathCount = 0;
        PlayerPrefs.SetInt("DeathCount", deathCount);
    }
}
