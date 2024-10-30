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
        if (isDead)
        {
            return;
        }
        
        Health--;//if have flamesword, duplicate
        anim.SetTrigger("Hit");
        
        isHit = true;
        anim.SetBool("InCombat", true);
        
        if (Health < 1)
        {
            AudioManager.Instance.PlayEnemySound(0);
            isDead = true;
            anim.SetTrigger("Death");
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
        }
    }
}
