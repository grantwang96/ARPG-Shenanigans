using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class NPCBlueprint : ScriptableObject {

    // these functions are called by brain states. BrainStates handle duration/timing
    public virtual void OnIdleEnter(NPCBehaviour npc) {
        // play idle animation
    }
    public virtual void OnIdleExecute(NPCBehaviour npc) {
        npc.CheckVision();
    }
    public virtual void OnIdleExit(NPCBehaviour npc) {

    }

    public virtual void OnMoveEnter(NPCBehaviour npc) {

    }
    public virtual void OnMoveExecute(NPCBehaviour npc) {
        npc.CheckVision();
    }
    public virtual void OnMoveExit(NPCBehaviour npc) {

    }

    public virtual void OnAttackEnter(NPCBehaviour npc) {

    }
    public virtual void OnAttackExecute(NPCBehaviour npc) {

    }
    public virtual void OnAttackExit(NPCBehaviour npc) {

    }
}
