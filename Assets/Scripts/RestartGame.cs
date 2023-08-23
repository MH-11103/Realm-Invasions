using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    //public int sceneIndex;
    public void Restart(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void nextLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
