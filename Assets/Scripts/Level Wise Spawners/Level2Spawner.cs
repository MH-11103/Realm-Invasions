using UnityEngine;

public class Level2Spawner : MonoBehaviour
{
    public GameObject characterPrefab;
    public GameObject secondCharacterPrefab; // Prefab for the second character
    public float radius = 100f;
    public float spawnDelay = 4f; // Time delay between spawning each character
    public float spawnDuration = 90f; // Total spawning duration

    private Transform spawnPoint; // Reference to the spawn point's transform
    private bool spawningFirstCharacter = true; // Whether to spawn the first character

    void Start()
    {
        spawnPoint = transform; // Assign the spawner's transform as the spawn point
        InvokeRepeating("SpawnCharacter", 0f, spawnDelay);

        // Schedule the second character spawn after 60 seconds
        Invoke("SpawnSecondCharacter", spawnDuration - 30f);
    }

    void SpawnCharacter()
    {
        if (spawningFirstCharacter)
        {
            // Generate a random angle within the circle
            float randomAngle = Random.Range(0f, Mathf.PI * 2f);

            // Calculate the position using trigonometry
            float x = Mathf.Cos(randomAngle) * radius;
            float z = Mathf.Sin(randomAngle) * radius;

            // Instantiate the character at the calculated position
            Vector3 spawnPosition = spawnPoint.position + new Vector3(x, 0f, z);
            GameObject newCharacter = Instantiate(characterPrefab, spawnPosition, Quaternion.identity);

            // Calculate the direction to the spawn point
            Vector3 directionToSpawnPoint = spawnPoint.position - newCharacter.transform.position;

            // Set the character's rotation to face the spawn point
            newCharacter.transform.rotation = Quaternion.LookRotation(directionToSpawnPoint);
        }
    }

    void SpawnSecondCharacter()
    {
        spawningFirstCharacter = false; // Stop spawning the first character

        // Generate a random angle within the circle
        float randomAngle = Random.Range(0f, Mathf.PI * 2f);

        // Calculate the position using trigonometry
        float x = Mathf.Cos(randomAngle) * radius;
        float z = Mathf.Sin(randomAngle) * radius;

        // Instantiate the second character at the calculated position
        Vector3 spawnPosition = spawnPoint.position + new Vector3(x, 0f, z);
        Instantiate(secondCharacterPrefab, spawnPosition, Quaternion.identity);
    }
}

