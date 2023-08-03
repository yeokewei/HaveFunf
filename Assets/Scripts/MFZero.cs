using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MFZero : MonoBehaviour
{

    public float moveSpeed = 2.5f;
    public float rotationSpeed = 5f;
    // public float 
    public float despawnTime = 5f;


    // private float timer = 0.0f;

    private Vector3 targetPosition;
    private Vector3 moveDirection;
    private Vector3 targetDirection;
    private Quaternion targetRotation;

    // private bool rotating = true;
    // private float rotationTime = 3f;
    // private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = Vector3.zero;
        moveDirection = (targetPosition - transform.position).normalized;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        // if (rotating)
        // {
        //     // print("rotating");
        //     // Rotate the prefab for the first 3 seconds
        //     timer += Time.deltaTime;
        //     Debug.Log("Time: " + timer);
        //     if (timer >= rotationTime)
        //     {
        //         rotating = false;
        //         timer = 0f;
        //         // print("stop rotating");
        //         Debug.Log("timer is 0"+ timer);
        //     }
        // }else{
        targetDirection = Vector3.zero - transform.position;
        // targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        // transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        // }
      
       
        Destroy(gameObject,despawnTime );
    
    }


 
}
