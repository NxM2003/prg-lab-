using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class charStates : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int damage;
    public int armor;

    public event System.Action<int, int> OnHealthChanged;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
     public virtual void TakeDamage(int damage) { 

        currentHealth -= damage;

        if(OnHealthChanged != null)
        {
            OnHealthChanged(maxHealth, currentHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
     }
    public virtual void Die()
    {
        Debug.Log(transform.name + " died!");
    }
}
