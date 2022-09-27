using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(TankController))]


public class Player : MonoBehaviour
{
    [Header("Projectiles")]
    public GameObject projectile;
    public Transform firePosition;
    [Header("Shoot Effects")]
    [SerializeField] protected AudioClip _shootSound;
    [SerializeField] protected ParticleSystem _shootParticle;
    [Header("Hurt Effects")]
    [SerializeField] protected AudioClip _hurtSound;
    [SerializeField] protected ParticleSystem _hurtParticle;
    [Header("Two Positions")]
    public Transform firstPosition;
    public Transform secondPosition;

    public CameraShake cameraShake;


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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(projectile, firstPosition.position, firstPosition.rotation);
            Instantiate(projectile, secondPosition.position, secondPosition.rotation);
            Feedback();
        }

    }

     private void OnCollisionEnter(Collision other)
     {
        if (other.gameObject.name == "Boss")
        {
            IDamageable damage = _playerCollider.GetComponent<IDamageable>();
            if (damage != null)
            {
                damage.TakeDamage(1);
                DamageFeedback();
                StartCoroutine(cameraShake.Shake(.5f, -1f));
            }
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

        private void DamageFeedback()
    {
        if (_shootSound != null)
        {
            AudioHelper.PlayClip2D(_hurtSound, 1f);

        }
        if (_shootParticle != null)
        {
            _shootParticle = Instantiate(_hurtParticle,
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
