using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAddon : MonoBehaviour
{
    public int damage;

    private Rigidbody rb;

    private bool targetHit;

    public GameObject chickenPrefab;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // make sure only to stick to the first target you hit
        if (targetHit)
            return;
        else
            targetHit = true;
        // check if you hit an enemy
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            Health enemy = collision.gameObject.GetComponent<Health>();

            enemy.TakeDamage(damage);

            // destroy projectile
            Destroy(gameObject);
            // GameObject chicken = GameObject.Find("Toon Chicken");
            // Destroy(chicken);

            // GameObject NewChicken = Instantiate(chickenPrefab);
        }

        // make sure projectile sticks to surface
        // rb.isKinematic = true;

        // make sure projectile moves with target
        // transform.SetParent(collision.transform);

        // Destroy(gameObject,6);
    }
}