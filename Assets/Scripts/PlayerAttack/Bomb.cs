using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float life = 3;
    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
