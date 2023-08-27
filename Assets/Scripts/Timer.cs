using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    public float timeValue = 90;
    public Text timerText;

    public int currentSceneIndex;
    public Player health;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //Debug.Log(currentSceneIndex);

    }

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }

        DisplayTime(timeValue);
        SceneManagementAfterLevel();

    }
    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void SceneManagementAfterLevel()
    {
        Debug.Log(currentSceneIndex);

        if (health.currentHealth <= 0)
        {
            Debug.Log("Health value is zero");
            switch (currentSceneIndex)
            {
                case 2:
                    SceneManager.LoadScene("GameOverLevel1");
                    Debug.Log("GameOver1");
                    break;
                case 3:
                    SceneManager.LoadScene("GameOverLevel2");
                    Debug.Log("GameOver2");
                    break;
                case 4:
                    SceneManager.LoadScene("GameOverLevel3");
                    Debug.Log("GameOver3");
                    break;
                case 5:
                    SceneManager.LoadScene("GameOverLevel4");
                    Debug.Log("GameOver4");
                    break;
                case 6:
                    SceneManager.LoadScene("GameOverLevel5");
                    Debug.Log("GameOver5");
                    break;
                default:
                    Debug.Log("DEFAULT");
                    break;


            }
            Debug.Log("CASE1");
        }
        if (timeValue <= 0 )
        {
            Debug.Log("Tiem value is zero");
            Debug.Log(health.currentHealth);

                Debug.Log("Health value is not zero");
                switch (currentSceneIndex)
                {
                    case 2:
                        SceneManager.LoadScene("VictoryScreen1");
                        Debug.Log("Victory1");
                        break;
                    case 3:
                        SceneManager.LoadScene("VictoryScreen2");
                        Debug.Log("Victory2");
                        break;
                    case 4:
                        SceneManager.LoadScene("VictoryScreen3");
                        Debug.Log("Victory3");
                        break;
                    case 5:
                        SceneManager.LoadScene("VictoryScreen4");
                        Debug.Log("Victory4");
                        break;
                    case 6:
                        SceneManager.LoadScene("VictoryScreen5");
                        Debug.Log("Victory5");
                        break;
                    default:
                        Debug.Log("DEFAULT");
                        break;
                }
                Debug.Log("CASE2");
            }
        }
    }
   

