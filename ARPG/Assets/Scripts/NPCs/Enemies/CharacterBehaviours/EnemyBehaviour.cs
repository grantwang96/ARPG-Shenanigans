using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : NPCBehaviour {

    protected override void Start() {
        base.Start();
        ChangeBrainState(new IdleState(blueprint.GetNewIdleTime));
    }

    public override void TakeDamage(int damage) {
        base.TakeDamage(damage);
    }

    public override void CheckVision() {
        base.CheckVision();
    }

    protected override void ReactToCharacter(CharacterBehaviour behaviour) {
        if (IsThreat(behaviour)) {
            currentTarget = behaviour;
            targetDestination = behaviour.transform.position;
            ChangeBrainState(new ChaseState());
        }
    }

    protected override bool IsThreat(CharacterBehaviour behaviour) {
        Faction otherFaction = behaviour.GetFaction;
        // use bitwise operation & to check if otherFaction is any of these potential threats
        bool isThreat = (otherFaction & (Faction.CIVILIAN | Faction.GUARD | Faction.PLAYER)) != 0;
        Debug.Log(isThreat);
        return isThreat;
    }
}
