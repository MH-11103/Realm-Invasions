using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject characterPrefab;
    public float radius = 20f;
    public float spawnDelay = 2f; // Time delay between spawning each character

    void Start()
    {
        SpawnCharactersInCircle();
    }

    void SpawnCharactersInCircle()
    {
        InvokeRepeating("SpawnCharacter", 0f, spawnDelay);
    }

    void SpawnCharacter()
    {
        // Generate a random angle within the circle
        float randomAngle = Random.Range(0f, Mathf.PI * 2f);

        // Calculate the position using trigonometry
        float x = Mathf.Cos(randomAngle) * radius;
        float z = Mathf.Sin(randomAngle) * radius;

        // Instantiate the character at the calculated position
        Vector3 spawnPosition = transform.position + new Vector3(x, 0f, z);
        GameObject newCharacter = Instantiate(characterPrefab, spawnPosition, Quaternion.identity);

        // Calculate the direction to the center
        Vector3 directionToCenter = transform.position - newCharacter.transform.position;

        // Set the character's rotation to face the center
        newCharacter.transform.rotation = Quaternion.LookRotation(directionToCenter);
    }
}
