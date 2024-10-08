using System;
using UnityEngine;
using System.Collections;

public class AcidEffect : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject, 5f);
    }
    private void Update()
    {
        float moveDistance = Time.deltaTime * 3;
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
