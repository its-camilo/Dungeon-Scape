using System;
using UnityEngine;
using System.Collections;

public class AcidEffect : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject, 2.5f);
    }
    private void Update()
    {
        float moveDistance = Time.deltaTime * 1.5f;
        transform.Translate(Vector3.right * moveDistance);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IDamageable hit = other.GetComponent<IDamageable>();
            
            if (hit != null)
            {
                hit.Damage();
                Destroy(this.gameObject);
            }
        }
    }
}
