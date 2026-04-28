using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator WeaponAnimator;
    public GameObject Weapon;
    public bool attacking;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    IEnumerator AttackRoutine()
    {
        Weapon.SetActive(true);
        attacking = true;
        WeaponAnimator.SetTrigger("Attack");

        yield return null; // wait one frame so state updates

        AnimatorStateInfo state = WeaponAnimator.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(state.length - 0.5f);

        Weapon.SetActive(false);
        attacking = false;
    }

    public void Attack()
    {
        if (!attacking)
        {
            StartCoroutine(AttackRoutine());
        }
    }
}
