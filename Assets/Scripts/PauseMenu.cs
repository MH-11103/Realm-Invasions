using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject PauseMenuPanel;

    public void Pause()
    {
        PauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        PauseMenuPanel.SetActive(false);
        Time .timeScale = 1f;
    }
    public void Restart(int sceneIndex)
    {
        Time.timeScale = 1f;
   

       SceneManager.LoadScene(sceneIndex);
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /* public void LoadLevel(int sceneIndex)
     {
         SceneManager.LoadScene(sceneIndex);

     }*/
}
