using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBlast : MonoBehaviour
{
    public int damageAmount = 20;
    public float life = 3;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target")) // Check if collided object has the "Target" tag
        {
            Destroy(collision.gameObject);
        }

        Destroy(gameObject);
    }
}
