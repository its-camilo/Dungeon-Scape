using System;
using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool canDamage = true;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable hit = other.GetComponent<IDamageable>();
        
        if (hit != null)
        {
            if (canDamage)
            {
                hit.Damage();
                canDamage = false;
                //StartCoroutine(ResetDamage());
            }
            
            hit.Damage();
        }
    }
    
    IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(0.000001f);
        canDamage = true;
    }
}
