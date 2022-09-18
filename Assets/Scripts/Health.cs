using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour, IDamageable
{

    private int  _currentHealth = 3;

    void Start()
    {
        _currentHealth = 3;
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        if(_currentHealth <= 0)
        {
            Kill();
        }
    }

}

