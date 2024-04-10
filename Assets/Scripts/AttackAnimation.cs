using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimation : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void DisableAttack()
    {
        GameManager.instance.canAttack = false;
    }

    public void EnableAttack()
    {
        GameManager.instance.canAttack = true;
    }

    public void ResetAttack()
    {
        GameManager.instance.attackStack = 0;
        animator.SetInteger("Attack", GameManager.instance.attackStack);
    }
}
