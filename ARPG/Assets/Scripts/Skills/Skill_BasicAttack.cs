using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Skill/Attack")]
public class Skill_BasicAttack : Skill {

    public override void Use(CharacterBehaviour brain) {
        int attackPower = brain.stats.attackPower;
        Debug.Log(brain.name + " attacked with " + attackPower + " attack power");
    }
}
