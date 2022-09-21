using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour, IDamageable
{

    private int  _currentHealth = 3;
    
    [SerializeField] Text _healthText;

    [Header("Effects")]
    [SerializeField] protected AudioClip _killSound;
    [SerializeField] protected ParticleSystem _killParticle;

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
        
        _healthText.GetComponent<Text>().text = "Health: " + _currentHealth;
        if (_currentHealth <= 0)
        {
            Kill();
            KillFeedback();
        }
    }

    private void KillFeedback()
    {
        if (_killParticle != null)
        {
            _killParticle = Instantiate(_killParticle,
                transform.position, Quaternion.identity);
        }
        if (_killSound != null)
        {
            AudioHelper.PlayClip2D(_killSound, 1f);
        }
    }

}

