using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{

    [SerializeField] Collider _bossCollider;
    [SerializeField] float ObjectSpeed;

    public GameObject projectile;
    public Transform firePosition;

    //public float speed;
    //private float waitTime;
    //public float startWaitTime;

    //public Transform[] moveSpots;
    //private int randomSpot;

    [SerializeField] MeshRenderer _meshRenderer;

    [SerializeField] Transform[] Positions;

    [SerializeField] protected AudioClip _shootSound;

    Transform NextPos;
    int NextPosIndex;

    [SerializeField] private float damageCooldown;
    private float cooldownTimer = Mathf.Infinity;

    public GameObject chargeEffect;

    void Start()
    {
        NextPos = Positions[0];
        //waitTime = startWaitTime;
        //randomSpot = Random.Range(0, moveSpots.Length);
    }

    void Update()
    {

        MoveGameObject();
        cooldownTimer += Time.deltaTime;
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

            //Instantiate(projectile, firePosition.position, firePosition.rotation);
            //Feedback();

            if (NextPosIndex == 1)
            {
                Instantiate(projectile, firePosition.position, firePosition.rotation);
                Feedback();
            }
            if (NextPosIndex == 2)
            {
                Instantiate(projectile, firePosition.position, firePosition.rotation);
                Feedback();
            }
            if (NextPosIndex == 3)
            {
                Instantiate(projectile, firePosition.position, firePosition.rotation);
                Feedback();
            }
            if (NextPosIndex == 4)
            {
                Instantiate(projectile, firePosition.position, firePosition.rotation);
                Feedback();
            }
            if (NextPosIndex == 5)
            {
                Instantiate(projectile, firePosition.position, firePosition.rotation);
                Feedback();

                chargeEffect.SetActive(true);

            }
            if (NextPosIndex == 5)
            {
                

                chargeEffect.SetActive(true);

            }
            if (NextPosIndex == 6)
            {
                
                chargeEffect.SetActive(false);

            }
            if (NextPosIndex == 8)
            {
                Instantiate(projectile, firePosition.position, firePosition.rotation);
                Feedback();
            }
            if (NextPosIndex == 9)
            {
                Instantiate(projectile, firePosition.position, firePosition.rotation);
                Feedback();
            }
            if (NextPosIndex == 12)
            {
                Instantiate(projectile, firePosition.position, firePosition.rotation);
                Feedback();
            }

            if (NextPosIndex >= Positions.Length)
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
                _meshRenderer.material.color = Color.red;
                cooldownTimer = 0;
            }
            if (cooldownTimer > damageCooldown)
            {
                _meshRenderer.material.color = Color.black;
            }
        }
    }

    private void Feedback()
    {
        if (_shootSound != null)
        {
            AudioHelper.PlayClip2D(_shootSound, 1f);

        }
     
    }

}
