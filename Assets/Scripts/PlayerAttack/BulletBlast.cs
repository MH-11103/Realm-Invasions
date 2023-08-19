using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBlastFireBoy : MonoBehaviour
{
    public int damageAmount = 60;
    public float life = 3;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("drone"))
        {
            other.gameObject.GetComponent<DronehealthManager>().TakeDamage(damageAmount);
            Destroy(gameObject);

        }
        else if (other.collider.CompareTag("blaster"))
        {
            other.gameObject.GetComponent<BlasterhealthManager>().TakeDamage(damageAmount);
            Destroy(gameObject);

        }
        else if (other.collider.CompareTag("spider"))
        {
            other.gameObject.GetComponent<BlasterhealthManager>().TakeDamage(damageAmount);
            Destroy(gameObject);

        }
    }
}
