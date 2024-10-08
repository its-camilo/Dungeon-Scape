using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    
    public override void Movement()
    {
        base.Movement();
    }
    
    public void Damage()
    {
        Health--;
        anim.SetTrigger("Hit");
        
        isHit = true;
        anim.SetBool("InCombat", true);
        
        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
        }
    }
}
