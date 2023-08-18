//using UnityEngine;

//public class DronehealthManager : MonoBehaviour
//{
//    public int maxHealth = 20;
//    public int currentHealth;

//    void Start()
//    {
//        currentHealth = maxHealth;
//    }

//    void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.CompareTag("Bullet")) // Assuming the prefab has a tag "Target"
//        {
//            //TakeDamage(20);// Decrease health when the prefab collides with the player
//            //Destroy(collision.gameObject); // Destroy the prefab
//            Destroy(gameObject);
//        }
//        if (collision.gameObject.CompareTag("Meteorite")) // Assuming the prefab has a tag "Target"
//        {
//            TakeDamage(35); // Decrease health when the prefab collides with the player
//            //Destroy(collision.gameObject); // Destroy the prefab
//        }
//        if (collision.gameObject.CompareTag("Bomb")) // Assuming the prefab has a tag "Target"
//        {
//            TakeDamage(60); // Decrease health when the prefab collides with the player
//            //Destroy(collision.gameObject); // Destroy the prefab
//        }
//    }

//    void TakeDamage(int damage)
//    {
//        currentHealth -= damage;

//        if (currentHealth == 0)
//        {
//            Destroy(gameObject);
//        }
//    }
//}

//using System;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class DronehealthManager : MonoBehaviour
//{
//    public int maxHealth = 1000;
//    public int currentHealth;

//    void Start()
//    {
//        currentHealth = maxHealth;
//    }

//    public void TakeDamage(int damage)
//    {
//        currentHealth -= damage;

//        if (currentHealth <= 0)
//        {
//            Destroy(gameObject);
//        }
//    }
//}

//// Attach this script to the same object as TowerManager
//public class CollisionHandler : MonoBehaviour
//{
//    private DronehealthManager Manager;

//    void Start()
//    {
//        Manager = GetComponent<DronehealthManager>();
//    }

//    void OnCollisionEnter(Collision collision)
//    {
//        Debug.Log("Collision detected with: " + collision.gameObject.tag);

//        //if (collision.gameObject.CompareTag("bullet"))
//        //{
//            //Manager.TakeDamage(20);

//        //}
//        //if (collision.gameObject.CompareTag("bomb"))
//        //{
//        //    Manager.TakeDamage(30);
//        //}
//        //else if (collision.gameObject.CompareTag("meteorite"))
//        //{
//        //    Manager.TakeDamage(60);
//        //}

//        Destroy(gameObject);
//    }
//}

//using UnityEngine;

//public class DronehealthManager : MonoBehaviour
//{

//    void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.CompareTag("bullet")) // Assuming the prefab has a tag "Target"
//        {
//            Destroy(gameObject);
//        }
//        if (collision.gameObject.CompareTag("Meteorite")) // Assuming the prefab has a tag "Target"
//        {
//            Destroy(gameObject);
//        }
//        if (collision.gameObject.CompareTag("Bomb")) // Assuming the prefab has a tag "Target"
//        {
//            Destroy(gameObject);
//        }
//    }
//}

using UnityEngine;

public class DronehealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Perform death logic here, such as playing death animations or spawning particle effects.
        Destroy(gameObject);
    }
}
