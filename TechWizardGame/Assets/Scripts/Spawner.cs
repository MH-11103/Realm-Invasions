using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] animalPrefabs;
    //int index;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawner",startDelay, spawnInterval);
    }
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    spawner();
        //}
    }

    private float posX = 20;
    private float posZ = 20;

    void spawner()
    {
        int index = Random.Range(0, animalPrefabs.Length); //random animal
        Vector3 pos = new Vector3(Random.Range(-posX, posZ), 0.5f, posZ); // random position
        //Instantiate(animalPrefabs[index], new Vector3(0,0,20), animalPrefabs[index].transform.rotation);
        Instantiate(animalPrefabs[index], pos, animalPrefabs[index].transform.rotation);
    }
}
