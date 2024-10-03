using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Create a public array of objects to spawn, we will fill this up using the Unity Editor
    public GameObject[] objectsToSpawn;

    float timeToNextSpawn; // Tracks how long we should wait before spawning a new object
    float timeSinceLastSpawn = 0.0f; //  Tracks the time since we last spawned somethhing

    public float minSpawnTime = 0.5f; // Minimum amount of time between spawning objects
    public float maxSpawnTime = 3.0f; //Maximum amount of time between spawning objects

    void Start()
    {
        //Random.Range returns a random float between two values
        timeToNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }

    void Update()
    {
      // Add Time.deltaTime returns the amount of time passed since the last frame.
      // This will create a float that counts up in seconds
      timeSinceLastSpawn = timeSinceLastSpawn + Time.deltaTime;

     //If we've counted past the amount of time we need to wait...
     if (timeSinceLastSpawn > timeToNextSpawn )
        {
            //Use Random.Range to pick a number between 0 and the amount of items we have on our object list
            int selection = Random.Range(0, objectsToSpawn.Length);

            //Instantiate spawns a GameObject - in this case we tell it to spawn a GameObject from our objectsToSpawn list
            //The second parameter in the brackets tells it where to spawn, so we've entered the position of the spawner.
            //The third parameter is for rotation, and Quaternion.identity means no rotation
            Instantiate(objectsToSpawn[selection], transform.position, Quaternion.identity);
            
            //After spawning, we select a new random time for the next spawn and set our timer back to zero
            timeToNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
            timeSinceLastSpawn = 0.01f;
            maxSpawnTime += 0.2f;
        }
    }
}
