using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TapAction : MonoBehaviour, IPointerDownHandler
{
    public Animator animator;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (GameManager.instance.canAttack)
        {
            if (GameManager.instance.attackStack == 0)
            {
                GameManager.instance.attackStack = 1;
                animator.SetInteger("Attack", GameManager.instance.attackStack);
            }
            else if (GameManager.instance.attackStack == 1)
            {
                GameManager.instance.attackStack = 2;
                animator.SetInteger("Attack", GameManager.instance.attackStack);
            }
            else if (GameManager.instance.attackStack == 2)
            {
                GameManager.instance.attackStack = 0;
                animator.SetInteger("Attack", GameManager.instance.attackStack);
            }
        }
    }
}
