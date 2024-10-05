using System;
using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool canDamage = true;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        
        IDamageable hit = other.GetComponent<IDamageable>();
        
        if (hit != null)
        {
            if (canDamage)
            {
                hit.Damage();
                Debug.Log("Damage() called");
                canDamage = false;
                StartCoroutine(ResetDamage());
            }
        }
    }
    
    IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(0.0001f);
        canDamage = true;
    }
}
