using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : EnemyBase
{
    public float StopTime { get; set; } = 1f;
    public float End = 2;
    private float _elapsedTime = 0;

    protected override void OnHit()
    {
        
        StartTime();
        MoveSpeed *= 0f;
        TimeLimit();
        
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= End)
        {
            MoveSpeed *= 5f;
        }

       
        //if (_elapsedTime <= StopTime)
        //{

        //Debug.Log("Slow Speed");
        //}
        //else if (_elapsedTime >= End)
        //{
        //MoveSpeed *= 5f;
        //Debug.Log("Noraml Speed");
        //}
    }

    private void TrackCooldown()
    {
        _elapsedTime += Time.deltaTime;
    }

    private void StartTime()
    {
        _elapsedTime = 0;
    }

    //private void Update()
    //{
        //_elapsedTime += Time.deltaTime;
        //Debug.Log(_elapsedTime);
    //}

    private void TimeLimit()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= End)
        {
            MoveSpeed *= 5f;
        }
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= End)
        {
            MoveSpeed *= 0.05f;
        }
    }
}
