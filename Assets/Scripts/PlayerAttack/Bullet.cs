using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damageAmount = 20;

    public float lifetime = 3;

    void Awake()
    {
        Destroy(gameObject, lifetime);
    }


    private void OnCollisionEnter(Collision other)
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