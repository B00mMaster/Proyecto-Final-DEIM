using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trophy : MonoBehaviour
{
    public ParticleSystem apples;
    public string NextScene;
    private void Start()
    {
        apples.Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            apples.Play();

            Invoke("ToNextScene", 8f);
        }
    }

    void ToNextScene()
    {
        SceneManager.LoadScene(NextScene);
    }
}
