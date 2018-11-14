using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : NPCBehaviour {

    protected override void Start() {
        base.Start();
        ChangeBrainState(new IdleState(blueprint.GetNewIdleTime)); // WIP: magic number
    }

    public override void TakeDamage(int damage) {
        base.TakeDamage(damage);
    }

    public override void CheckVision() {
        base.CheckVision();
    }
}
