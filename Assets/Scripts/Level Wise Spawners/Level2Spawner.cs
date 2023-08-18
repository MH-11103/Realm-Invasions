//using UnityEngine;

//public class Level2Spawner : MonoBehaviour
//{
//    public GameObject characterPrefab;
//    public GameObject secondCharacterPrefab;
//    public float radius = 20f;
//    public float spawnDelay = 2f;

//    private Transform spawnPoint;
//    private bool secondCharacterSpawned = false;
//    private float timerDuration = 90f; // Total duration of the timer in seconds
//    private float currentTime = 0f;    // Current time elapsed
//    private bool spawningSecondCharacter = false;

//    void Start()
//    {
//        spawnPoint = transform;
//        SpawnCharactersInCircle();
//    }

//    void Update()
//    {
//        // Update the timer and check if it's time to spawn the second character
//        if (!spawningSecondCharacter)
//        {
//            currentTime += Time.deltaTime;
//            if (currentTime >= timerDuration - 30f)
//            {
//                spawningSecondCharacter = true;
//                SpawnSecondCharacter();
//            }
//        }
//    }

//    void SpawnCharactersInCircle()
//    {
//        InvokeRepeating("SpawnCharacter", 0f, spawnDelay);
//    }

//    void SpawnCharacter()
//    {
//        float randomAngle = Random.Range(0f, Mathf.PI * 2f);
//        float x = Mathf.Cos(randomAngle) * radius;
//        float z = Mathf.Sin(randomAngle) * radius;
//        Vector3 spawnPosition = spawnPoint.position + new Vector3(x, 0f, z);

//        GameObject newCharacter = Instantiate(characterPrefab, spawnPosition, Quaternion.identity);
//        Vector3 directionToSpawnPoint = spawnPoint.position - spawnPosition;
//        newCharacter.transform.rotation = Quaternion.LookRotation(directionToSpawnPoint);
//    }

//    void SpawnSecondCharacter()
//    {
//        float randomAngle = Random.Range(0f, Mathf.PI * 2f);
//        float x = Mathf.Cos(randomAngle) * radius;
//        float z = Mathf.Sin(randomAngle) * radius;
//        Vector3 spawnPosition = spawnPoint.position + new Vector3(x, 0f, z);

//        GameObject newCharacter = Instantiate(secondCharacterPrefab, spawnPosition, Quaternion.identity);
//        Vector3 directionToSpawnPoint = spawnPoint.position - spawnPosition;
//        newCharacter.transform.rotation = Quaternion.LookRotation(directionToSpawnPoint);
//    }
//}

using UnityEngine;

public class Level2Spawner : MonoBehaviour
{
    public GameObject characterPrefab;
    public GameObject secondCharacterPrefab;
    public float radius = 20f;
    public float spawnDelay = 2f;

    private Transform spawnPoint;
    private bool spawningSecondCharacter = false;
    private bool isLast30Seconds = false;

    private float currentTime = 0f;
    private float timerDuration = 90f;
    private float timeThresholdForSecondCharacter = 60f;

    void Start()
    {
        spawnPoint = transform;
        SpawnCharactersInCircle();
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (!spawningSecondCharacter && currentTime >= timeThresholdForSecondCharacter)
        {
            spawningSecondCharacter = true;
            SpawnSecondCharacter();
        }

        if (currentTime >= timerDuration)
        {
            CancelInvoke("SpawnCharacter");
        }
    }

    void SpawnCharactersInCircle()
    {
        InvokeRepeating("SpawnCharacter", 0f, spawnDelay);
    }

    void SpawnCharacter()
    {
        if (!isLast30Seconds)
        {
            float randomAngle = Random.Range(0f, Mathf.PI * 2f);
            float x = Mathf.Cos(randomAngle) * radius;
            float z = Mathf.Sin(randomAngle) * radius;
            Vector3 spawnPosition = spawnPoint.position + new Vector3(x, 0f, z);

            GameObject newCharacter = Instantiate(characterPrefab, spawnPosition, Quaternion.identity);
            Vector3 directionToSpawnPoint = spawnPoint.position - spawnPosition;
            newCharacter.transform.rotation = Quaternion.LookRotation(directionToSpawnPoint);
        }
    }

    void SpawnSecondCharacter()
    {
        float randomAngle = Random.Range(0f, Mathf.PI * 2f);
        float x = Mathf.Cos(randomAngle) * radius;
        float z = Mathf.Sin(randomAngle) * radius;
        Vector3 spawnPosition = spawnPoint.position + new Vector3(x, 0f, z);

        GameObject newCharacter = Instantiate(secondCharacterPrefab, spawnPosition, Quaternion.identity);
        Vector3 directionToSpawnPoint = spawnPoint.position - spawnPosition;
        newCharacter.transform.rotation = Quaternion.LookRotation(directionToSpawnPoint);
    }
}

