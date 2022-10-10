using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{

    [SerializeField] protected AudioClip _impactSound;
    [SerializeField] protected ParticleSystem _impactParticle;

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.name == "Tank")
        {
            Destroy(gameObject);
            Feedback();
        }
        if (other.gameObject.name == "Boss")
        {
            Destroy(gameObject);
            Feedback();
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
