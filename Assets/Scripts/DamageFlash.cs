using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    Color firstColor;
    float flashTime = .15f;


    void Start()
    {
        
        //meshRenderer = GetComponent<MeshRenderer>();
        firstColor = meshRenderer.material.color;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "PlayerProjectile(Clone)")
        {
                StartCoroutine(EFlash()); 
        }
    }

    void FlashStart()
    {
        meshRenderer.material.color = Color.red;
        Invoke("FlashEnd", flashTime);
    }

    void FlashEnd()
    {
        meshRenderer.material.color = firstColor;

    }

    IEnumerator EFlash()
    {
        meshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(flashTime);
        meshRenderer.material.color = firstColor;
    }
}
