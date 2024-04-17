using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public BaseCollider baseCollider;
    void Start()
    {
        baseCollider=GameObject.FindGameObjectWithTag("health").GetComponent<BaseCollider>();
        healthBar.GetComponent<Slider>();
        healthBar.maxValue = baseCollider.maxHealth;
        healthBar.value = baseCollider.currentHealth;
    }
   

    // Update is called once per frame
    void Update()
    {
        healthBar.value = baseCollider.currentHealth;
    }
    public void SetHealth(int health)
    {
        healthBar.value = health;
    }
}
