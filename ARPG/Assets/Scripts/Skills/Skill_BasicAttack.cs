using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Skill/BasicAttack")]
public class Skill_BasicAttack : Skill {
    public override void Use(CharacterBehaviour brain) {
        int attackPower = brain.stats.attackPower;
        Debug.Log(brain.name + " attacked with " + attackPower + " attack power");
    }

    public override void OnSkillEnd(CharacterBehaviour brain) {
        
    }

    public override void OnSkillStart(CharacterBehaviour brain) {
        
    }

}
