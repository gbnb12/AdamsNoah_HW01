using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{
    [RequireComponent(typeof(Rigidbody))]

    public abstract class Projectile : MonoBehaviour
    {
        protected abstract void Impact(Collision otherCollision);

       
        

        [Header("Settings")]
        [SerializeField] protected float Speed = .25f;
        [SerializeField] protected Rigidbody RB;
        [SerializeField] protected float increaseSpeed = .50f;

        [Header("Effects")]
        [SerializeField] protected AudioClip _impactSound;
        [SerializeField] protected ParticleSystem _impactParticle;

        
        private void OnCollisionEnter(Collision collision)
        {

            Impact(collision);
            Feedback();
           
        }

        private void Awake()
        {
            if(RB == null)
            {
                RB = GetComponent<Rigidbody>();
            }
        }

        private void FixedUpdate()
        {
            Move();
        }

        protected virtual void Move()
        {
            Vector3 moveOffset = transform.forward * Speed;
            RB.MovePosition(RB.position + moveOffset);
            if (Input.GetKeyDown(KeyCode.Q))
            {
                 Speed += increaseSpeed;
                
            }
        }

        private void Feedback()
        {
            if (_impactParticle != null)
            {
                _impactParticle = Instantiate(_impactParticle,
                    transform.position, Quaternion.identity);
            }
            if (_impactSound != null)
            {
                AudioHelper.PlayClip2D(_impactSound, 1f);
                
            }
            
        }

    }
}