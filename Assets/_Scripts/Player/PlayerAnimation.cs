using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private readonly string walkAnimation = "Walk";
    private readonly string attackAnimation = "Attack";
    private readonly string deathAnimation = "Death";
    private readonly string idleAnimation = "Idle";
    private readonly string takeDamageAnimation = "TakeDamage";

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayWalkAnimation()
    {
        animator.SetBool(walkAnimation, true);
    }

    public void StopWalkAnimation()
    {
        animator.SetBool(walkAnimation, false);
    }

    public void PlayAttackAnimation()
    {
        animator.SetTrigger(attackAnimation);
    }

    public void PlayDeathAnimation()
    {
        animator.SetTrigger(deathAnimation);
    }

    public void PlayIdleAnimation()
    {
        animator.SetBool(idleAnimation, true);
    }

    public void StopIdleAnimation()
    {
        animator.SetBool(idleAnimation, false);
    }

    public void PlayTakeDamageAnimation()
    {
        animator.SetTrigger(takeDamageAnimation);
    }

}
