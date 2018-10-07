using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains statistics for character objects. 0 is the bottom score
/// </summary>
public class CharacterStats : MonoBehaviour {

    private int _attackPower;
    public int attackPower { get { return _attackPower; } }
    private int _magicAttackPower;
    public int magicAttackPower { get { return _magicAttackPower; } }
    private int _defense;
    public int defense { get { return _defense; } }
    private int _magicDefense;
    public int magicDefense { get { return _magicDefense; } }
    private int _agility;
    public int agility { get { return _agility; } }

    public void Initialize() {

    }
}
