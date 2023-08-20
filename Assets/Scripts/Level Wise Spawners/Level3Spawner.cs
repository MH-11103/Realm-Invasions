using UnityEngine;

public class Level3Spawner : MonoBehaviour
{
    public GameObject characterPrefab;
    public GameObject secondCharacterPrefab; // Prefab for the second character
    public float radius = 100f;
    public float firstCharacterSpawnDelay = 4f; // Time delay for spawning the first character
    public float secondCharacterSpawnInterval = 15f; // Interval for spawning the second character

    private Transform spawnPoint; // Reference to the spawn point's transform
    private float firstCharacterSpawnTimer = 0f;
    private float secondCharacterSpawnTimer = 0f;

    void Start()
    {
        spawnPoint = transform; // Assign the spawner's transform as the spawn point
    }

    void Update()
    {
        // Update timers
        firstCharacterSpawnTimer += Time.deltaTime;
        secondCharacterSpawnTimer += Time.deltaTime;

        // Spawn the first character every firstCharacterSpawnDelay seconds
        if (firstCharacterSpawnTimer >= firstCharacterSpawnDelay)
        {
            SpawnCharacter();
            firstCharacterSpawnTimer = 0f; // Reset the timer
        }

        // Spawn the second character every secondCharacterSpawnInterval seconds
        if (secondCharacterSpawnTimer >= secondCharacterSpawnInterval)
        {
            SpawnSecondCharacter();
            secondCharacterSpawnTimer = 0f; // Reset the timer
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

//using UnityEngine;

//public class Level3Spawner : MonoBehaviour
//{
//    public GameObject characterPrefab;
//    public GameObject secondCharacterPrefab; // Prefab for the second character
//    public float radius = 100f;
//    public float firstCharacterSpawnDelay = 4f;
//    public float secondCharacterSpawnInterval = 15f;

//    private Transform spawnPoint;
//    private float firstCharacterSpawnTimer = 0f;
//    private float secondCharacterSpawnTimer = 0f;

//    void Start()
//    {
//        spawnPoint = transform;
//        InvokeRepeating("SpawnCharacter", 0f, firstCharacterSpawnDelay);
//        InvokeRepeating("SpawnSecondCharacter", 0f, secondCharacterSpawnInterval);
//    }

//    void SpawnCharacter()
//    {
//        float randomAngle = Random.Range(0f, Mathf.PI * 2f);
//        float x = Mathf.Cos(randomAngle) * radius;
//        float z = Mathf.Sin(randomAngle) * radius;
//        Vector3 spawnPosition = spawnPoint.position + new Vector3(x, 0f, z);
//        GameObject newCharacter = Instantiate(characterPrefab, spawnPosition, Quaternion.identity);
//        Vector3 directionToSpawnPoint = spawnPoint.position - newCharacter.transform.position;
//        newCharacter.transform.rotation = Quaternion.LookRotation(directionToSpawnPoint);
//    }

//    void SpawnSecondCharacter()
//    {
//        float randomAngle = Random.Range(0f, Mathf.PI * 2f);
//        float x = Mathf.Cos(randomAngle) * radius;
//        float z = Mathf.Sin(randomAngle) * radius;
//        Vector3 spawnPosition = spawnPoint.position + new Vector3(x, 0f, z);
//        GameObject newCharacter = Instantiate(secondCharacterPrefab, spawnPosition, Quaternion.identity);
//        Vector3 directionToSpawnCenter = spawnPoint.position - newCharacter.transform.position;

//        // Calculate rotation to face the spawn center while keeping the Y axis up
//        Quaternion rotation = Quaternion.LookRotation(new Vector3(directionToSpawnCenter.x, 0f, directionToSpawnCenter.z), Vector3.up);
//        newCharacter.transform.rotation = rotation;
//    }
//}


