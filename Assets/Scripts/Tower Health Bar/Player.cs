using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth = 1500;
    public int currentHealth;

    public HealthBar healthBar;

    void Start()
    {

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
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
    }
}


