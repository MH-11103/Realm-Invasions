using UnityEngine;

public class Meteorite : MonoBehaviour
{
    public int damageAmount = 20;

    public float lifetime = 3;

    void Awake()
    {
        Destroy(gameObject, lifetime);
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Target") || other.collider.CompareTag("drone"))
        {
            other.gameObject.GetComponent<DronehealthManager>().TakeDamage(damageAmount);

        }

        Destroy(gameObject);
    }
}