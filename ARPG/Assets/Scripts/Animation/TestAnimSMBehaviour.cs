﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimSMBehaviour : StateMachineBehaviour {

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        base.OnStateEnter(animator, animatorStateInfo, layerIndex);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        base.OnStateExit(animator, stateInfo, layerIndex);
    }
}
