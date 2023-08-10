using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 100;
    public float invisibilityTime = 0.5f;

    public HealthBar healthBar;

    private float timer = 0f;
    private bool takenDamage = true;


    void Start()
    {
        curHealth = maxHealth;
    }

    void Update()
    {
        if (!takenDamage)
        {
            timer += Time.deltaTime;
            // Debug.Log(timer);
            if (timer >= invisibilityTime)
            {
                Debug.Log("Take Damage");
                takenDamage = true;
                timer = 0.0f;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (takenDamage)
        {
            takenDamage = false; //invisibility mode
            curHealth -= damage;

            healthBar.SetHealth(curHealth);
            if (curHealth <= 0)
            {
                Die();
            }
        }

    }

    void Die()
    {
        Debug.Log("Player died");
        // SceneTransitionManager.singleton.GoToSceneAsync(2);
        SceneManager.LoadScene("Ending Scene");
        Destroy(gameObject);
        
    }
}