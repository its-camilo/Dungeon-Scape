using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        //Health = base.health;
    }

    public void Damage()
    {
        //
    }
}
