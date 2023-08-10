using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{

    //import game object
    public GameObject prefabToSpawn;
    public GameObject prefabToSpawn2;
    public GameObject prefabToSpawn3;
    public GameObject prefabToSpawn4;
    public GameObject prefabToSpawn5;

    public AudioSource source;
    public AudioClip evilSound;

    public float speed = 5f;
    public float circleRadius = 5f;
    public float changeDirectionTimeMin = 1f;
    public float changeDirectionTimeMax = 3f;
    public float pauseTimeMin = 1f;
    public float pauseTimeMax = 3f;

    public float angleStart = 75f;
    public float angleEnd = 110f;


    // public GameObject canvasPrefab;
    // public int maxCanvasInstances = 9;

    private float currentAngle;
    private bool isMoving = true;
    private float directionTimer;
    private float pauseTimer;

    // private float minSpawnInterval = 10f;
    // private float maxSpawnInterval = 15f;

    private Transform player;
    // private float spawnRadius = 5f; 
    private Vector3 center; // Center point of the circle
    // private float angle = 0f; // Current angle on the circle
    // private int canvasInstanceCount = 0;
    private float random;


    private void Start()
    {

        // Calculate the center point of the circle based on the object's initial position
        // center = transform.position;
        // center = new Vector3(0.0f,0.0f,0.0f);
        directionTimer = Random.Range(changeDirectionTimeMin, changeDirectionTimeMax);
        currentAngle = Random.Range(angleStart, angleEnd);
        MoveInCircle();

        player = GameObject.FindGameObjectWithTag("Player").transform;
        // StartCoroutine(SpawnCanvasRoutine());

    }

    private void Update()
    {
        if (isMoving)
        {
            // Move the object in a circular path
            MoveInCircle();


            // Decrease the direction timer
            directionTimer -= Time.deltaTime;

            // Check if it's time to stop moving
            if (directionTimer <= 0f)
            {
                // Change the direction randomly and reset the direction timer
                // currentAngle = Random.Range(0f, 30f);
                currentAngle = Random.Range(angleStart, angleEnd);
                directionTimer = Random.Range(changeDirectionTimeMin, changeDirectionTimeMax);

                // Pause the movement for a random amount of time
                isMoving = false;
                pauseTimer = Random.Range(pauseTimeMin, pauseTimeMax);

                //Spawn a prefab to throw
                //make a list of prefabToSpawn, and choose any of them randomly
                GameObject[] prefabs = { prefabToSpawn, prefabToSpawn2, prefabToSpawn3, prefabToSpawn4, prefabToSpawn5 };
                int randomIndex = Random.Range(0, prefabs.Length);
                GameObject randomPrefab = prefabs[randomIndex];
                GameObject spawnedPrefab = Instantiate(randomPrefab, transform.position, Quaternion.identity);

                source.PlayOneShot(evilSound);
            }
        }
        else
        {
            // Pause the movement
            pauseTimer -= Time.deltaTime;

            if (pauseTimer <= 0f)
            {
                // Resume moving after the pause time is over
                isMoving = true;
            }
        }
    }

    private void MoveInCircle()
    {

        // Calculate the new position based on the current angle and circle radius
        float x = Mathf.Cos(currentAngle * Mathf.Deg2Rad) * circleRadius;
        float z = Mathf.Sin(currentAngle * Mathf.Deg2Rad) * circleRadius;

        // Set the new position
        transform.position = new Vector3(x, 0f, z);

        // Increment the angle to make the object move in the circle
        // random = Random.Range(0, 2);
        // Debug.Log(random);
        // currentAngle += speed * Time.deltaTime * (random - );


    }

    // private IEnumerator SpawnCanvasRoutine()
    // {
    //     while (canvasInstanceCount < maxCanvasInstances)
    //     {
    //         float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    //         yield return new WaitForSeconds(spawnInterval);

    //         // Generate a random angle (in radians) for the spawn position around the player.
    //         float randomAngle = Random.Range(0f, 2f * Mathf.PI);
    //         Vector3 spawnPosition = player.position + new Vector3(Mathf.Cos(randomAngle), 0f, Mathf.Sin(randomAngle)) * spawnRadius;

    //         // Spawn the canvas prefab and make it face the player.
    //         GameObject canvasInstance = Instantiate(canvasPrefab, spawnPosition, Quaternion.identity);
    //         canvasInstance.transform.LookAt(player);
    //         //rotate canvas along x axis 90
    //         canvasInstance.transform.Rotate(Vector3.right, 90f);
    //         canvasInstance.transform.position += Vector3.up;



    //         canvasInstanceCount++;
    //         Debug.Log("spawnnumber : " + canvasInstanceCount);
    //     }
    // }
}
// private void Update()
// {
//     // Increment the angle based on the time and speed
//     currentAngle += speed * Time.deltaTime;

//     // Calculate the new position on the circle based on the angle and radius
//     float x = center.x + radius * Mathf.Cos(angle);
//     float z = center.z + radius * Mathf.Sin(angle);

//     // Set the object's new position
//     transform.position = new Vector3(x, transform.position.y, z);
// }
// }
