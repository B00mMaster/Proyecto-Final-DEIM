using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{

    public Player_Life Player_Life;
    public string nextScene;
    public void LoadScene()
    {
        Player_Life.ResetDeathCounter();

        SceneManager.LoadScene(nextScene);
        
    }
}
