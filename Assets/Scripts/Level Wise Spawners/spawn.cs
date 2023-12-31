//using UnityEngine;

//public class EnemySpawner : MonoBehaviour
//{
//    public GameObject characterPrefab;
//    public float radius = 20f;
//    public float spawnDelay = 2f; // Time delay between spawning each character

//    void Start()
//    {
//        SpawnCharactersInCircle();
//    }

//    void SpawnCharactersInCircle()
//    {
//        InvokeRepeating("SpawnCharacter", 0f, spawnDelay);
//    }

//    void SpawnCharacter()
//    {
//        // Generate a random angle within the circle
//        float randomAngle = Random.Range(0f, Mathf.PI * 2f);

//        // Calculate the position using trigonometry
//        float x = Mathf.Cos(randomAngle) * radius;
//        float z = Mathf.Sin(randomAngle) * radius;

//        // Instantiate the character at the calculated position
//        Vector3 spawnPosition = transform.position + new Vector3(x, 0f, z);
//        GameObject newCharacter = Instantiate(characterPrefab, spawnPosition, Quaternion.identity);

//        // Calculate the direction to the center
//        Vector3 directionToCenter = transform.position - newCharacter.transform.position;

//        // Set the character's rotation to face the center
//        newCharacter.transform.rotation = Quaternion.LookRotation(directionToCenter);
//    }
//}


using UnityEngine;

public class Level1Spawner : MonoBehaviour
{
    public GameObject characterPrefab;
    public float radius = 100f;
    public float spawnDelay = 4f; // Time delay between spawning each character

    private Transform spawnPoint; // Reference to the spawn point's transform

    void Start()
    {
        spawnPoint = transform; // Assign the spawner's transform as the spawn point
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
        Vector3 spawnPosition = spawnPoint.position + new Vector3(x, 0f, z);
        GameObject newCharacter = Instantiate(characterPrefab, spawnPosition, Quaternion.identity);

        // Calculate the direction to the spawn point
        Vector3 directionToSpawnPoint = spawnPoint.position - newCharacter.transform.position;

        // Set the character's rotation to face the spawn point
        newCharacter.transform.rotation = Quaternion.LookRotation(directionToSpawnPoint);
    }
}
