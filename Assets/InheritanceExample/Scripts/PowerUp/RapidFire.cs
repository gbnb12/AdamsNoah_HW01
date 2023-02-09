using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFire : PowerUpBase
{
    //public TurretController FireCooldown;

    protected override void OnHit()
    {
        //FindObjectOfType<TurretController>(); 
    }

    protected override void PowerUp()
    {
        //GetComponent<TurretController>().FireCooldown = 0.25f;
        FindObjectOfType<TurretController>().FireCooldown = 0.25f;
        //Debug.Log("Start");
    }

    protected override void PowerDown()
    {
        //GetComponent<TurretController>().FireCooldown = 0.5f;
        FindObjectOfType<TurretController>().FireCooldown = 0.5f;
        //Debug.Log("Finish");
    }
}
