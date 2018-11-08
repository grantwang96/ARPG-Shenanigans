using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BrainState {

    protected NPCBehaviour npcBehaviour;

    public virtual void Enter(NPCBehaviour behaviour) { npcBehaviour = behaviour; }
    public virtual void Execute() { }
    public virtual void Exit() { }
}

public class IdleState : BrainState {

    float idleTime;

    public override void Enter(NPCBehaviour behaviour) {
        base.Enter(behaviour);
        
    }

    public override void Execute() {
        npcBehaviour.CheckVision();
    }

    public override void Exit() {
        
    }
}

public class WalkState : BrainState {
    
    public override void Enter(NPCBehaviour behaviour) {
        base.Enter(behaviour);
    }

    public override void Execute() {
        npcBehaviour.CheckVision();
    }

    public override void Exit() {

    }
}

public class RunState : BrainState {

    public override void Enter(NPCBehaviour behaviour) {
        base.Enter(behaviour);
    }

    public override void Execute() {

    }

    public override void Exit() {

    }
}

public class AttackState : BrainState {

    public override void Enter(NPCBehaviour behaviour) {
        base.Enter(behaviour);

    }

    public override void Execute() {

    }

    public override void Exit() {

    }
}
