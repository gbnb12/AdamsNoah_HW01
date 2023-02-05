using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : EnemyBase
{
    public float StopTime { get; set; } = 1f;

    public bool IsHit { get; private set; } = true;

    private float _elapsedTime = 0;

    protected override void OnHit()
    {
        MoveSpeed = 0f;
        StartTime();
        TimeWatch();
        
    }

    private void Coutdown()
    {
        //_elapsedTime += Time.deltaTime;
        if (_elapsedTime >= StopTime)
        {
            MoveSpeed = 0.10f;
        }
    }

    private void TrackCooldown()
    {
        if (IsHit == true)
        {
            //MoveSpeed *= 0f;
            //_elapsedTime += Time.deltaTime;
            if (_elapsedTime >= StopTime)
            {
                IsHit = false;
                MoveSpeed *= 0.05f;
            }
        }
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
        Debug.Log(_elapsedTime);
        TimeWatch();
    }
}
