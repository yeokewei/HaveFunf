using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBoundary : MonoBehaviour
{

    public float horizontalInput;
    public float verticalInput;
    public float xRange = 5;
    public float zRange = 5;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //horizontalInput = Input.GetAxis("Horizontal");
        //transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);

        //verticalInput = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);



        //Debug.Log(horizontalInput + verticalInput);

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z > -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, - zRange);
        }
    }
}
