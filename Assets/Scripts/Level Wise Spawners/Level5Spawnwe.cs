using UnityEngine;

public class Level5Spawner : MonoBehaviour
{
    public GameObject characterPrefab;
    public GameObject secondCharacterPrefab;
    public GameObject thirdCharacterPrefab; // Prefab for the third character
    public float radius = 20f;
    public float spawnDelay = 2f;
    public float secondCharacterSpawnDelay = 10f; // Delay for spawning the second character
    public float spawnDuration = 90f;

    private Transform spawnPoint;
    private bool spawningFirstCharacter = true;
    private bool spawningSecondCharacter = true;

    void Start()
    {
        spawnPoint = transform;
        InvokeRepeating("SpawnCharacter", 0f, spawnDelay);
        InvokeRepeating("SpawnSecondCharacter", 0f, secondCharacterSpawnDelay);

        // Schedule the third character spawn after 60 seconds
        Invoke("SpawnThirdCharacter", spawnDuration - 30f);
    }

    void SpawnCharacter()
    {
        if (spawningFirstCharacter)
        {
            float randomAngle = Random.Range(0f, Mathf.PI * 2f);
            float x = Mathf.Cos(randomAngle) * radius;
            float z = Mathf.Sin(randomAngle) * radius;
            Vector3 spawnPosition = spawnPoint.position + new Vector3(x, 0f, z);
            GameObject newCharacter = Instantiate(characterPrefab, spawnPosition, Quaternion.identity);
            Vector3 directionToSpawnPoint = spawnPoint.position - newCharacter.transform.position;
            newCharacter.transform.rotation = Quaternion.LookRotation(directionToSpawnPoint);
        }
    }

    void SpawnSecondCharacter()
    {
        if (spawningSecondCharacter)
        {
            float randomAngle = Random.Range(0f, Mathf.PI * 2f);
            float x = Mathf.Cos(randomAngle) * radius;
            float z = Mathf.Sin(randomAngle) * radius;
            Vector3 spawnPosition = spawnPoint.position + new Vector3(x, 0f, z);
            GameObject newCharacter = Instantiate(secondCharacterPrefab, spawnPosition, Quaternion.identity);
            Vector3 directionToSpawnPoint = spawnPoint.position - newCharacter.transform.position;
            newCharacter.transform.rotation = Quaternion.LookRotation(directionToSpawnPoint);
        }
    }

    void SpawnThirdCharacter()
    {
        spawningFirstCharacter = false;
        spawningSecondCharacter = false;

        float randomAngle = Random.Range(0f, Mathf.PI * 2f);
        float x = Mathf.Cos(randomAngle) * radius;
        float z = Mathf.Sin(randomAngle) * radius;
        Vector3 spawnPosition = spawnPoint.position + new Vector3(x, 0f, z);
        Instantiate(thirdCharacterPrefab, spawnPosition, Quaternion.identity);
    }
}
