using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float dieTime = 3f;
    public GameObject collisionExplosion;

    void Start()
    {
        Destroy(gameObject, dieTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            GameObject explosion = (GameObject)Instantiate(collisionExplosion,
                    transform.position, transform.rotation);

            Destroy(gameObject);
            Destroy(explosion, 3f);
            return;
        }
    }
}
