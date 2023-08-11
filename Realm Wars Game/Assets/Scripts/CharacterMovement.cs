using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f;
    private Transform center;

    void Start()
    {
        center = GameObject.FindGameObjectWithTag("SpawnCenter").transform;
    }

    void Update()
    {
        // Calculate the direction to the center
        Vector3 directionToCenter = center.position - transform.position;

        // Move towards the center
        transform.Translate(directionToCenter.normalized * speed * Time.deltaTime, Space.World);
    }
}
