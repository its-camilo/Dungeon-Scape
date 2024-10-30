using UnityEngine;

public class Skeleton : Enemy, IDamageable
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
        if (isDead)
        {
            return;
        }
        
        //Health--;
        
        if (!GameManager.Instance.HasFlameSword)
        {
            Health--;
        }
        
        if (GameManager.Instance.HasFlameSword)
        {
            Health-= 2;
        }
        
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);
        
        if (Health < 1)
        {
            AudioManager.Instance.PlayEnemySound(1);
            isDead = true;
            anim.SetTrigger("Death");
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
        }
    }
}
