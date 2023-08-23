using UnityEngine;
using UnityEngine.SceneManagement;


public class VictoryMenu : MonoBehaviour
{
    //public int LevelSceneIndex;
    public void ReplayLevel(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Nextlevel(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
