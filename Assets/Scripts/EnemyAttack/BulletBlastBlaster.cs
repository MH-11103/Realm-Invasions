using UnityEngine;

public class BulletBlastBlaster : MonoBehaviour
{
    public int damageAmount = 60;
    public float life = 3;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("misty"))
        {
            other.gameObject.GetComponent<MistyHealthManager>().TakeDamage(damageAmount);
            Destroy(gameObject);

        }
        else if (other.collider.CompareTag("mage"))
        {
            other.gameObject.GetComponent<MageHealthManager>().TakeDamage(damageAmount);
            Destroy(gameObject);

        }
        else if (other.collider.CompareTag("fireboy"))
        {
            other.gameObject.GetComponent<FireBoyHealthManager>().TakeDamage(damageAmount);
            Destroy(gameObject);

        }
    }
}
