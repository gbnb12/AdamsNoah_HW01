using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(TankController))]
public class Player : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePosition;
    [SerializeField] protected AudioClip _shootSound;
    [SerializeField] protected ParticleSystem _shootParticle;

    //public GameObject projectileInstance;
    //[SerializeField] int _maxHealth = 3;
    //int _currentHealth;

    TankController _tankController;
    [SerializeField] Collider _playerCollider;

    //public int theScore;
    //[SerializeField] Text _scoreText;
    //[SerializeField] Text _healthText;

    private void Awake()
    {
        _tankController = GetComponent<TankController>();
    }

    //private void Start()
    //{
        //_currentHealth = _maxHealth;
    //}

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Instantiate(projectile, firePosition.position, firePosition.rotation);
            Feedback();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        IDamageable damage = _playerCollider.GetComponent<IDamageable>();
        if (damage != null)
        {

            damage.TakeDamage(1);

            
        }

    }

    private void Feedback()
    {
        if (_shootSound != null)
        {
            AudioHelper.PlayClip2D(_shootSound, 1f);

        }
        if (_shootParticle != null)
        {
            _shootParticle = Instantiate(_shootParticle,
                transform.position, Quaternion.identity);
        }
    }

    //public void IncreaseHealth(int amount)
    //{
    //_currentHealth += amount;
    //_currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
    //Debug.Log("Player's health: " + _currentHealth);
    // _healthText.GetComponent<Text>().text = "Health: " + _currentHealth;
    // }

    //public void DecreaseHealth(int amount)
    //{
    // _currentHealth -= amount;
    // Debug.Log("Player's health: " + _currentHealth);
    // _healthText.GetComponent<Text>().text = "Health: " + _currentHealth;
    //if (_currentHealth <= 0)
    // {
    // Kill();
    //}
    //}

    //public void Kill()
    //{
    //gameObject.SetActive(false);

    //}



    //public void Score()
    //{
    // theScore += 1;
    // _scoreText.GetComponent<Text>().text = "Treasure: " + theScore;

    // }


}
