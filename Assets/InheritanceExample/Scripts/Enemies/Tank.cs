using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : EnemyBase
{

    [SerializeField] float _stopTime;
    protected override void OnHit()
    {
        MoveSpeed *= 0;   
    }
}
