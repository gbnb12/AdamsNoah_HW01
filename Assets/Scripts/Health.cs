using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Inheritance
{

    [RequireComponent(typeof(Rigidbody))]

    public class Health : MonoBehaviour
    {


        [SerializeField] int _maxHealth = 3;
        int _currentHealth;
        [SerializeField] Text _healthText;

        private void Start()
        {
            _currentHealth = _maxHealth;
        }

        public void IncreaseHealth(int amount)
        {
            _currentHealth += amount;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
            Debug.Log("Player's health: " + _currentHealth);
            _healthText.GetComponent<Text>().text = "Health: " + _currentHealth;
        }

        public void DecreaseHealth(int amount)
        {
            _currentHealth -= amount;
            Debug.Log("Player's health: " + _currentHealth);
            _healthText.GetComponent<Text>().text = "Health: " + _currentHealth;
            if (_currentHealth <= 0)
            {
                Kill();
            }
        }

        public void Kill()
        {
            gameObject.SetActive(false);

        }
    }

}