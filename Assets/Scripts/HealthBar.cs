using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public string tags;

    private Slider healthBar;
    private Health gameObjectHealth;

    private void Start()
    {
        gameObjectHealth = GameObject.FindGameObjectWithTag(tags).GetComponent<Health>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = gameObjectHealth.maxHealth;
        healthBar.value = gameObjectHealth.maxHealth;
    }

    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }
}