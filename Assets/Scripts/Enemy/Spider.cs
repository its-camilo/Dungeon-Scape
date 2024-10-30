using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health { get; set; }
    public GameObject acidEffectPrefab;

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    
    public override void Update()
    {
        //
    }

    public void Damage()
    {
        if (isDead)
        {
            return;
        }
        
        Health--;//if have flamesword, duplicate
        
        if (Health < 1)
        {
            AudioManager.Instance.PlayEnemySound(2);
            isDead = true;
            anim.SetTrigger("Death");
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
        }
    }
    
    public override void Movement()
    {
        //base.Movement();
    }
    
    public void Attack()
    {
        Instantiate(acidEffectPrefab, transform.position, Quaternion.identity);
    }
}
