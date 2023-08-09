using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [Header("Stats")]
    public int health;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Take damage boss");

        if (health <= 0){
            DestroyEnemy();
            Debug.Log("You Win");
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}