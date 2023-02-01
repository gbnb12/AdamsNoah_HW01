using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : EnemyBase
{

    [SerializeField] private Transform _powerupSpawnLoc;
    [SerializeField] private GameObject _powerupToSpawn;

    protected override void OnHit()
    {
        MoveSpeed *= 2;
    }

    public override void Kill()
    {
        base.Kill();
        SpawnPowerup();  
    }

    public void SpawnPowerup()
    {
        Instantiate(_powerupToSpawn,
            _powerupSpawnLoc.position, transform.rotation);
    }
}
