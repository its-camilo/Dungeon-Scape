using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private Animator swordAnimator;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        swordAnimator = transform.GetChild(1).GetComponent<Animator>();
    }
    
    public void Move(float move)
    {
        anim.SetFloat("Move", Mathf.Abs(move));
    }
    
    public void Jump(bool jumping)
    {
        anim.SetBool("Jumping", jumping);
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
        swordAnimator.SetTrigger("SwordAnimation");
    }
    
    public void Death()
    {
        anim.SetTrigger("Death");
    }
}