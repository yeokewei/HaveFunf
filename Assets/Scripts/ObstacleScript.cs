using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    public float despawnTime = 5f;
    public float delayAfterSpawn = 0.0f;

    private bool isDelayedonSpawn = false;

    void Start()
    {
        if (delayAfterSpawn > 0.0f)
        {
            isDelayedonSpawn = true;
        }
        else
        {
            isDelayedonSpawn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDelayedonSpawn)
        {
            delayAfterSpawn -= Time.deltaTime;
            if (delayAfterSpawn <= 0.0f)
            {
                isDelayedonSpawn = false;
                transform.Translate(Vector3.back * moveSpeed * Time.deltaTime); // Vector3.back: A shorthand for writing Vector3(0, 0, -1).
                Destroy(gameObject, despawnTime);
            }
            return;
        }
        else
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime); // Vector3.back: A shorthand for writing Vector3(0, 0, -1).
            Destroy(gameObject, despawnTime);
        }

    }
}
