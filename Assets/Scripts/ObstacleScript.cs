using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    public float despawnTime = 5f;

    // private Vector3 targetPosition;
    // private Vector3 moveDirection;
    // private Vector3 targetDirection;
    // private Quaternion targetRotation;


    void Start()
    {
        // targetPosition = Vector3.zero;
        // moveDirection = (targetPosition - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime); // Vector3.back: A shorthand for writing Vector3(0, 0, -1).
        Destroy(gameObject, despawnTime);
    }
}
