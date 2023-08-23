using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth = 1500;
    public int currentHealth;

    public HealthBar healthBar;

    private float timer = 90f; // 90 seconds timer
    private bool isTimerActive = true;

    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (isTimerActive)
        {
            timer -= Time.deltaTime; // Decrement the timer based on real time
            if (timer <= 0 || currentHealth == 0)
            {
                // Timer has reached 0, do something (e.g., game over logic)
                isTimerActive = false; // Stop the timer
                switch (currentSceneIndex){
                    case 2:
                        SceneManager.LoadScene("GameOverLevel1");
                        break;
                    case 3:
                        SceneManager.LoadScene("GameOverLevel2");
                        break;
                    case 4:
                        SceneManager.LoadScene("GameOverLevel3");
                        break;
                    case 5:
                        SceneManager.LoadScene("GameOverLevel4");
                        break;
                    case 6:
                        SceneManager.LoadScene("GameOverLevel5");
                        break;
                }
            }
            else if (timer <= 0 || currentHealth > 0)
            {
                // Timer has reached 0, do something (e.g., game over logic)
                isTimerActive = false; // Stop the timer
                switch (currentSceneIndex)
                {
                    case 2:
                        SceneManager.LoadScene("VictoryScreen1");
                        break;
                    case 3:
                        SceneManager.LoadScene("VictoryScreen2");
                        break;
                    case 4:
                        SceneManager.LoadScene("VictoryScreen3");
                        break;
                    case 5:
                        SceneManager.LoadScene("VictoryScreen4");
                        break;
                    case 6:
                        SceneManager.LoadScene("VictoryScreen5");
                        break;
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("drone")) 
        {
            TakeDamage(20); 
            Destroy(collision.gameObject); 
        }
        if (collision.gameObject.CompareTag("blaster")) 
        {
            TakeDamage(40); 
            Destroy(collision.gameObject); 
        }
        if (collision.gameObject.CompareTag("BlasterBomb")) 
        {
            TakeDamage(40); 
            Destroy(collision.gameObject); 
        }
        if (collision.gameObject.CompareTag("spider")) 
        {
            TakeDamage(100); 
            Destroy(collision.gameObject); 
        }   
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
        if (currentHealth == 0)
        {
            switch (currentSceneIndex)
            {
                case 2:
                    SceneManager.LoadScene("GameOverLevel1");
                    break;
                case 3:
                    SceneManager.LoadScene("GameOverLevel2");
                    break;
                case 4:
                    SceneManager.LoadScene("GameOverLevel3");
                    break;
                case 5:
                    SceneManager.LoadScene("GameOverLevel4");
                    break;
                case 6:
                    SceneManager.LoadScene("GameOverLevel5");
                    break;
            }
        }

    }
}


