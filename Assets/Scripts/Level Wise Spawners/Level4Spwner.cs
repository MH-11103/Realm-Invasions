//using UnityEngine;

//public class Level4Spawner : MonoBehaviour
//{
//    public GameObject characterPrefab;
//    public GameObject secondCharacterPrefab; // Prefab for the second character
//    public float radius = 100f;
//    public float spawnDelay = 4f; // Time delay between spawning each character


//    private Transform spawnPoint; // Reference to the spawn point's transform
//    private float timeElapsed = 0f;

//    void Start()
//    {
//        spawnPoint = transform; // Assign the spawner's transform as the spawn point
//        InvokeRepeating("SpawnCharacter", 0f, spawnDelay);
//    }

//    void Update()
//    {
//        timeElapsed += Time.deltaTime;

//        // Check if it's time to spawn the second character
//        if ((timeElapsed % 6f) < spawnDelay)
//        {
//            SpawnSecondCharacter();
//        }
//    }

//    void SpawnCharacter()
//    {
//        // Generate a random angle within the circle
//        float randomAngle = Random.Range(0f, Mathf.PI * 2f);

//        // Calculate the position using trigonometry
//        float x = Mathf.Cos(randomAngle) * radius;
//        float z = Mathf.Sin(randomAngle) * radius;

//        // Instantiate the character at the calculated position
//        Vector3 spawnPosition = spawnPoint.position + new Vector3(x, 0f, z);
//        GameObject newCharacter = Instantiate(characterPrefab, spawnPosition, Quaternion.identity);

//        // Calculate the direction to the spawn point
//        Vector3 directionToSpawnPoint = spawnPoint.position - newCharacter.transform.position;

//        // Set the character's rotation to face the spawn point
//        newCharacter.transform.rotation = Quaternion.LookRotation(directionToSpawnPoint);
//    }

//    void SpawnSecondCharacter()
//    {
//        // Generate a random angle within the circle
//        float randomAngle = Random.Range(0f, Mathf.PI * 2f);

//        // Calculate the position using trigonometry
//        float x = Mathf.Cos(randomAngle) * radius;
//        float z = Mathf.Sin(randomAngle) * radius;

//        // Instantiate the second character at the calculated position
//        Vector3 spawnPosition = spawnPoint.position + new Vector3(x, 0f, z);
//        Instantiate(secondCharacterPrefab, spawnPosition, Quaternion.identity);
//    }
//}

using UnityEngine;

public class Level4Spawner : MonoBehaviour
{
    public GameObject characterPrefab;
    public GameObject secondCharacterPrefab;
    public float radius = 100f;
    public float firstCharacterSpawnDelay = 4f;
    public float secondCharacterSpawnInterval = 8f;

    private Transform spawnPoint;
    private float firstCharacterSpawnTimer = 0f;
    private float secondCharacterSpawnTimer = 0f;

    void Start()
    {
        spawnPoint = transform;
    }

    void Update()
    {
        firstCharacterSpawnTimer += Time.deltaTime;
        secondCharacterSpawnTimer += Time.deltaTime;

        if (firstCharacterSpawnTimer >= firstCharacterSpawnDelay)
        {
            SpawnCharacter();
            firstCharacterSpawnTimer = 0f;
        }

        if (secondCharacterSpawnTimer >= secondCharacterSpawnInterval)
        {
            SpawnSecondCharacter();
            secondCharacterSpawnTimer = 0f;
        }
    }

    void SpawnCharacter()
    {
        float randomAngle = Random.Range(0f, Mathf.PI * 2f);
        float x = Mathf.Cos(randomAngle) * radius;
        float z = Mathf.Sin(randomAngle) * radius;
        Vector3 spawnPosition = spawnPoint.position + new Vector3(x, 0f, z);
        GameObject newCharacter = Instantiate(characterPrefab, spawnPosition, Quaternion.identity);
        Vector3 directionToSpawnPoint = spawnPoint.position - newCharacter.transform.position;
        newCharacter.transform.rotation = Quaternion.LookRotation(directionToSpawnPoint);
    }

    void SpawnSecondCharacter()
    {
        float randomAngle = Random.Range(0f, Mathf.PI * 2f);
        float x = Mathf.Cos(randomAngle) * radius;
        float z = Mathf.Sin(randomAngle) * radius;
        Vector3 spawnPosition = spawnPoint.position + new Vector3(x, 0f, z);
        GameObject newCharacter = Instantiate(secondCharacterPrefab, spawnPosition, Quaternion.identity);
        Vector3 directionToSpawnCenter = spawnPoint.position - newCharacter.transform.position;

        // Calculate rotation to face the spawn center while keeping the Y axis up
        Quaternion rotation = Quaternion.LookRotation(new Vector3(directionToSpawnCenter.x, 0f, directionToSpawnCenter.z), Vector3.up);
        newCharacter.transform.rotation = rotation;
    }
}

