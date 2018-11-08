using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : CharacterAnimationHandler {
    
    private void OnEnable() {
        RegisterCallbacks();
    }

    private void OnDisable() {
        DeregisterCallbacks();
    }

    private void RegisterCallbacks() {
        GameplayController.Instance.AttackEvent += OnAttack;
    }

    private void DeregisterCallbacks() {
        GameplayController.Instance.AttackEvent += OnAttack;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(GameplayController.Instance != null) {
            float mag = GameplayController.Instance.walkVector.magnitude;
            anim.SetFloat("Move", mag);
        }
	}

    private void OnAttack() {
        anim.SetInteger("AttackComboIndex", GameplayController.Instance.AttackComboIndex);
        anim.SetTrigger("Attack");
    }
}
