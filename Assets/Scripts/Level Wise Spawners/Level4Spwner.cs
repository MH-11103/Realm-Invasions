using UnityEngine;

public class Level4Spawner : MonoBehaviour
{
    public GameObject characterPrefab;
    public GameObject secondCharacterPrefab; // Prefab for the second character
    public float radius = 20f;
    public float spawnDelay = 2f; // Time delay between spawning each character
    public float spawnDuration = 90f; // Total spawning duration

    private Transform spawnPoint; // Reference to the spawn point's transform
    private float timeElapsed = 0f;

    void Start()
    {
        spawnPoint = transform; // Assign the spawner's transform as the spawn point
        InvokeRepeating("SpawnCharacter", 0f, spawnDelay);
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        // Check if it's time to spawn the second character
        if (timeElapsed >= 30f && (timeElapsed % 6f) < spawnDelay)
        {
            SpawnSecondCharacter();
        }
    }

    void SpawnCharacter()
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

    void SpawnSecondCharacter()
    {
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
