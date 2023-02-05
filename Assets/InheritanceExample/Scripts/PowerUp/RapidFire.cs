using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFire : PowerUpBase
{
    public TurretController FireCooldown;
    protected override void OnHit()
    {
        FindObjectOfType<TurretController>();
        
    }

    protected override void PowerUp()
    {
        //FireCooldown = 0.25f;
       
        //Debug.Log("Start");
    }

    protected override void PowerDown()
    {
        //Debug.Log("Finish");
    }
}
