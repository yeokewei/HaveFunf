using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed =20;
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireBullet(ActivateEventArgs arg){
        Transform cam = GameObject.Find("Main Camera").transform;
        Transform attackPoint = GameObject.Find("ObjectSpawnArea").transform;
        GameObject spawnBullet =  Instantiate(bullet);
        spawnBullet.transform.position = spawnPoint.position;
        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;
    
        if(Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        // add force
        Vector3 forceToAdd = forceDirection * 400 + transform.up * 0;
        spawnBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
        // spawnBullet.GetComponent<Rigidbody>().AddForce(forceToAdd, ForceMode.Impulse);

    }
}
