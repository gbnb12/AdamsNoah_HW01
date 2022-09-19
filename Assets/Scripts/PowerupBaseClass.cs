using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class PowerupBaseClass : MonoBehaviour
{
    protected abstract void Collect(Player player);

    [SerializeField] float _movementSpeed = 1;
    [SerializeField] float _powerupTime = 1;

    [SerializeField] ParticleSystem _collectParticles;
    [SerializeField] AudioClip _collectSound;

    [SerializeField] private Material myMaterial;



    bool _poweredUp = false;

    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

       

    }

    public void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        

            if (player != null && _poweredUp == false)
            {
                StartCoroutine(PowerupSequence(player));
                Collect(player);

                Feedback();

                gameObject.SetActive(false);
            }
        
    }

    IEnumerator PowerupSequence(Player player)
    {
        _poweredUp = true;

        //ActivatePowerup(player);

        

        yield return new WaitForSeconds(_powerupTime);

       //DeactivatePowerup(player);
        

        _poweredUp = false;
    }

    

    protected virtual void Movement(Rigidbody rb)
    {
        Quaternion turnOffset = Quaternion.Euler(0, _movementSpeed, 0);
        rb.MoveRotation(_rb.rotation * turnOffset);
    }

    private void FixedUpdate()
    {
        Movement(_rb);
    }

    private void Feedback()
    {
        if (_collectParticles != null)
        {
            _collectParticles = Instantiate(_collectParticles,
                transform.position, Quaternion.identity);
        }

        if (_collectSound != null)
        {
            AudioHelper.PlayClip2D(_collectSound, 1f);
        }
    }

  

    
}
