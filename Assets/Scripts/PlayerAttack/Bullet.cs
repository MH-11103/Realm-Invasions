//using UnityEngine;

//public class Bullet : MonoBehaviour
//{
//    public float life = 3;
//    BlasterhealthManager blasterhealthManager;

//    void Awake()
//    {
//        Destroy(gameObject, life);
//    }

//    void OnCollisionEnter(Collision collision)
//    {

//        //if (collision.gameObject.CompareTag("drone")) // Check if collided object has the "Target" tag
//        //{
//        //    Destroy(collision.gameObject);
//        //}
//        if (collision.gameObject.CompareTag("drone")) // Check if collided object has the "Target" tag
//        {
//            blasterhealthManager.TakeDamage(20);
//        }

//        Destroy(gameObject);
//    }
//}

using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damageAmount = 20;

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Target"))
        {
            other.gameObject.GetComponent<DronehealthManager>().TakeDamage(damageAmount);

        }

        Destroy(gameObject);
    }
}
