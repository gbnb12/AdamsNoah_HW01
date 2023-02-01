using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class PowerUpBase : MonoBehaviour
{
    [SerializeField] protected float PowerupDuration = 2;
    [SerializeField] GameObject _visualsToDeactivate = null;
    [SerializeField] Collider _colliderToDeactivate = null;
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] private AudioClip _hitSound;

    //public float EndPowerTime { get; set; } = 1f;
    private float _elapsedPowerTime;

    protected abstract void OnHit();
    protected abstract void PowerUp();
    protected abstract void PowerDown();

    private void OnTriggerEnter(Collider other)
    {
        Projectile projectile = other.GetComponent<Projectile>();
        if (projectile != null)
        {
            AudioHelper.PlayClip2D(_hitSound, 1, .1f);
            OnHit();
            PowerUp();
            TrackCooldown();
            _colliderToDeactivate.enabled = false;
            _visualsToDeactivate.SetActive(false);
        }
    }
    private void TrackCooldown()
    {
        _elapsedPowerTime += Time.deltaTime;
        if (_elapsedPowerTime >= PowerupDuration)
        {
            PowerDown();
            AudioHelper.PlayClip2D(_deathSound, 1, .1f); 
            Destroy(gameObject);
        }
    }

    private void StartTime()
    {
        _elapsedPowerTime = 0;
    }

    private void Update()
    {
        //TrackCooldown();
    }
}
