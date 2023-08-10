using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ThrowingScript : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    // public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;

    bool readyToThrow;
    private List<InputDevice> devicesWithPrimaryButton;
    

    private void Start()
    {
        readyToThrow = true;
        devicesWithPrimaryButton = new List<InputDevice>();
        Debug.Log( devicesWithPrimaryButton.Count);
        foreach (var device in devicesWithPrimaryButton)
        {
            Debug.Log(string.Format("Device name '{0}' has role '{1}'", device.name, device.role.ToString()));
        }

    }

    private void Update()
    {
        // if(Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0)
        // {
        //     Throw();
        // }
        foreach (var device in devicesWithPrimaryButton)
        {
            bool triggerValue;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue && totalThrows > 0)
            {
                Debug.Log("Throw");
                Throw();
            }
        }
        // if( readyToThrow && totalThrows > 0)
        // {
            
        //     // Throw();
        //     XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        //     grabbable.activated.AddListener(FireBullet);
        // }
    }

    public void FireBullet(ActivateEventArgs arg){ 
        readyToThrow = false;

        // instantiate object to throw
        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);
        // Debug.Log("Spawn Bomb");

        // get rigidbody component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // calculate direction
        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;

        if(Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        // add force
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;
    }

    private void Throw()
    // public void Throw(ActivateEventArgs a)
    {
        readyToThrow = false;

        // instantiate object to throw
        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);
        // Debug.Log("Spawn Bomb");

        // get rigidbody component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // calculate direction
        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;

        if(Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        // add force
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;

        // implement throwCooldown
        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }
}