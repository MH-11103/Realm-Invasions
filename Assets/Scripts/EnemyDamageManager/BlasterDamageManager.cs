using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterDamageManager : MonoBehaviour
{
    public int damageAmount = 40;

    private void OnCollisionEnter(Collision other)
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
