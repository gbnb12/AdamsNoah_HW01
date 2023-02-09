using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : EnemyBase
{
    public float StopTime { get; set; } = 1f;

    private float _elapsedTime = 0;

    protected override void OnHit()
    {
        MoveSpeed = 0f;
        StartTime();
        TimeWatch(); 
    }

    private void StartTime()
    {
        _elapsedTime = 0;
    }

    private void TimeWatch()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= StopTime)
        {
            MoveSpeed = 0.05f;
        }
    }

    private void Update()
    {
        //Debug.Log(_elapsedTime);
        TimeWatch();
    }
}
