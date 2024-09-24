using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    
    public void Move(float move)
    {
        anim.SetFloat("Move", Mathf.Abs(move));
    }
    
    public void Jump(bool jumping)
    {
        anim.SetBool("Jumping", jumping);
    }
}
