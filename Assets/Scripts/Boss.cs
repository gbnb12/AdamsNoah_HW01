using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{

    [SerializeField] Collider _bossCollider;
    [SerializeField] float ObjectSpeed;

    //public float speed;
    //private float waitTime;
    //public float startWaitTime;

    //public Transform[] moveSpots;
    //private int randomSpot;

    [SerializeField] Transform[] Positions;
    Transform NextPos;
    int NextPosIndex;

    void Start()
    {
        NextPos = Positions[0];
        //waitTime = startWaitTime;
        //randomSpot = Random.Range(0, moveSpots.Length);
    }

    void Update()
    {

        MoveGameObject();

        //transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        //if(Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        //{
            //if(waitTime <= 0)
            //{
                //randomSpot = Random.Range(0, moveSpots.Length);
                //waitTime = startWaitTime;
            //}
            //else
            //{
                //waitTime -= Time.deltaTime;
            //}
        //}
    }

    void MoveGameObject()
    {
        if(transform.position == NextPos.position)
        {
            NextPosIndex++;
            if(NextPosIndex >= Positions.Length)
            {
                NextPosIndex = 0;
            }
            NextPos = Positions[NextPosIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, NextPos.position, ObjectSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "PlayerProjectile(Clone)") 
        {
            IDamageable damage = _bossCollider.GetComponent<IDamageable>();
            if (damage != null)
            {
                damage.TakeDamage(1);
            }
        }
    }
}
