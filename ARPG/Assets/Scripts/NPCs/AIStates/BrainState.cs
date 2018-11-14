using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BrainState {

    protected NPCBehaviour npcBehaviour;

    public virtual void Enter(NPCBehaviour behaviour) {
        npcBehaviour = behaviour;
    }
    public virtual void Execute() {
        // Apply NPC state update loop
    }
    public virtual void Exit() {
        // Apply any final changes/calculations before switching to new state
    }
}

public class TransitionState : BrainState {

    public TransitionState(float time) : base() {

    }
}

public class IdleState : BrainState {

    float idleTime;
    float idleStartTime;

    public IdleState(float length) : base() {
        idleTime = length;
    }

    public override void Enter(NPCBehaviour behaviour) {
        base.Enter(behaviour);
        idleStartTime = Time.time;
        npcBehaviour.Blueprint.OnIdleEnter(behaviour);
    }

    public override void Execute() {
        // idle time is over, change to walk mode
        if(Time.time - idleStartTime > idleTime) {
            npcBehaviour.ChangeBrainState(new MoveState(npcBehaviour.Blueprint.WalkSpeed));
        }
        // perform normal idle behavior
        npcBehaviour.Blueprint.OnIdleExecute(npcBehaviour);
    }
    
    public override void Exit() {
        npcBehaviour.Blueprint.OnIdleExit(npcBehaviour);
    }
}

public class MoveState : BrainState {

    float moveSpeed;

    public MoveState(float speed) : base() {
        moveSpeed = speed;
    }

    public override void Enter(NPCBehaviour behaviour) {
        base.Enter(behaviour);
        npcBehaviour.Blueprint.OnMoveEnter(npcBehaviour);
    }

    public override void Execute() {
        npcBehaviour.Blueprint.OnMoveExecute(npcBehaviour);
    }

    public override void Exit() {
        npcBehaviour.Blueprint.OnMoveExit(npcBehaviour);
    }
}

/// <summary>
/// Runs for the duration of an attack animation
/// </summary>
public class AttackState : BrainState {

    public override void Enter(NPCBehaviour behaviour) {
        base.Enter(behaviour);
        npcBehaviour.Blueprint.OnAttackEnter(npcBehaviour);
    }

    public override void Execute() {
        npcBehaviour.Blueprint.OnAttackExecute(npcBehaviour);
    }

    public override void Exit() {
        npcBehaviour.Blueprint.OnAttackExit(npcBehaviour);
    }
}

public class SkillState : BrainState {

    private Skill skill;

    public SkillState(Skill newSkill) : base() {
        skill = newSkill;
    }

    public override void Enter(NPCBehaviour behaviour) {
        base.Enter(behaviour);
    }

    public override void Execute() {
        base.Execute();
    }

    public override void Exit() {
        base.Exit();
    }
}
