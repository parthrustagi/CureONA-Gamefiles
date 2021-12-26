using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;
    public bool Marja = false;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        animator.SetFloat("Vertical", GameManager.Instance.InputController.Vertical);
        animator.SetFloat("Horizontal", GameManager.Instance.InputController.Horizontal);
        animator.SetBool("IsWalking", GameManager.Instance.InputController.IsWalking);
        animator.SetBool("IsSprinting", GameManager.Instance.InputController.IsSprinting);
        animator.SetBool("IsCrouched", GameManager.Instance.InputController.IsCrouched);

        if(Marja)
        {
            animator.SetBool("Died", true);
        }
    }
	
	IEnumerator Alive()
    {
		yield return new WaitForSeconds(4);
		animator.SetBool("Died", false);
	}

    public void PlayerIsDead()
    {
        Marja = true;
    }
	
	public void PlayerStays()
    {
		animator.SetBool("Died", true);
		StartCoroutine(Alive());
    }
    
}
