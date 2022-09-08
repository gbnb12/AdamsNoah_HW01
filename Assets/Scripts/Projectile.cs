using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{
    [RequireComponent(typeof(Rigidbody))]

    public class Projectile : MonoBehaviour
    {
        

        [Header("Settings")]
        [SerializeField] protected float Speed = .25f;
        [SerializeField] protected Rigidbody RB;

        [Header("Effects")]
        [SerializeField] protected AudioClip _impactSound;
        [SerializeField] protected ParticleSystem _impactParticle;

        private void OnCollisionEnter(Collision collision)
        {
            
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
        }

    }
}