using UnityEngine;

public class Meteorite : MonoBehaviour
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
