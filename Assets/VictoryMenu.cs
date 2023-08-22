using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class VictoryMenu : MonoBehaviour
{
    public int LevelSceneIndex;
    public void Replay()
    {
        SceneManager.LoadScene(LevelSceneIndex) ;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(7);
    }



}
