using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    
    public void Damage()
    {
        Debug.Log("Skeleton - Damage()");
        Health--;
        anim.SetTrigger("Hit");
        
        isHit = true;
        anim.SetBool("InCombat", true);
        
        if (Health < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
