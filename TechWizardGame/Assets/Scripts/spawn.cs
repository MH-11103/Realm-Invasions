using UnityEngine;
using UnityEngine.TextCore.Text;

public class spawn : MonoBehaviour
{
    public GameObject characterPrefab;
    public int numberOfCharacters = 10;
    public float radius = 5f;
    public float spawnDelay = 1f; // Time delay between spawning each character
    private int charactersSpawned = 0;

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
        if (charactersSpawned >= numberOfCharacters)
        {
            // Stop invoking the method if all characters are spawned
            CancelInvoke("SpawnCharacter");
            return;
        }
        
        float angle = charactersSpawned * Mathf.PI * 2f / numberOfCharacters;// angle for the character to spawn from around the circle

        // position on circle using trigonometry
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;
        //--------------------------------------

        Vector3 spawnPosition = transform.position + new Vector3(x, 0f, z); // setting the position for character to spawn from
        GameObject newCharacter = Instantiate(characterPrefab, spawnPosition, Quaternion.identity);// spawning the character
       
        Vector3 directionToCenter = transform.position - newCharacter.transform.position; // direction to the center of the circle

        // Set the character's rotation to face the center
        newCharacter.transform.rotation = Quaternion.LookRotation(directionToCenter); //for character to facethe center
 
        charactersSpawned++;// character spawn count
    }
}
