using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class PowerUpBase : MonoBehaviour
{
    [SerializeField] GameObject _visualsToDeactivate = null;
    [SerializeField] Collider _colliderToDeactivate = null;

    [SerializeField] private AudioClip _deathSound;
    [SerializeField] private AudioClip _hitSound;

    public float PowerupDuration { get; set; } = 2f;

    private float _elapsedPowerTime = 0;

    public bool IsReady { get; private set; } = false;

    protected abstract void OnHit();
    protected abstract void PowerUp();
    protected abstract void PowerDown();

    private void OnTriggerEnter(Collider other)
    {
        Projectile projectile = other.GetComponent<Projectile>();
        if (projectile != null)
        {
            OnHit();
            PowerUp();

            AudioHelper.PlayClip2D(_hitSound, 1, .1f);
            _colliderToDeactivate.enabled = false;
            _visualsToDeactivate.SetActive(false);

            StartCooldown();
            TrackCoutdown();

        }
    }

    private void StartCooldown()
    {
        IsReady = true;
        _elapsedPowerTime = 0;
    }

    private void TrackCoutdown()
    {
        if (IsReady == true)
        {
            _elapsedPowerTime += Time.deltaTime;
            if (_elapsedPowerTime >= PowerupDuration)
            {
                IsReady = false;
                PowerDown();
                AudioHelper.PlayClip2D(_deathSound, 1, .1f);
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        StartCooldown();
        TrackCoutdown();

    }
}
