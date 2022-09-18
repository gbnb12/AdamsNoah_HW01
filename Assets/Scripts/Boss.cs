using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    [SerializeField] Collider _bossCollider;
  

    private void OnCollisionEnter(Collision collision)
    {

        IDamageable damage = _bossCollider.GetComponent<IDamageable>();
        if (damage != null)
        {
            
            damage.TakeDamage(1);
            
            
        }

    }
}
