using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth = 1000;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        TakeDamage(20);
    //    }
    //}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("drone")) // Assuming the prefab has a tag "EnemyPrefab"
        {
            TakeDamage(20); // Decrease health when the prefab collides with the player
            Destroy(collision.gameObject); // Destroy the prefab
        }
        if (collision.gameObject.CompareTag("blaster")) // Assuming the prefab has a tag "EnemyPrefab"
        {
            TakeDamage(40); // Decrease health when the prefab collides with the player
            Destroy(collision.gameObject); // Destroy the prefab
        }
        if (collision.gameObject.CompareTag("spider")) // Assuming the prefab has a tag "EnemyPrefab"
        {
            TakeDamage(60); // Decrease health when the prefab collides with the player
            Destroy(collision.gameObject); // Destroy the prefab
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
        if (currentHealth == 0)
        {
            SceneManager.LoadScene(10);

        }
    }

}
