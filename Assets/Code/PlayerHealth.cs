using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int startHealth;
    private int health;

    private void Start()
    {
        health = startHealth;
    }

    public void TakeDamage(int damage)
    {
        if(health - damage <= 0)
        {
            Die();
        }
        else
        {
            health -= damage;
        }
    }

    private void Die()
    {
        health = 0;
        Debug.Log("Player died, LOL");
    }
}
