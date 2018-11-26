using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// The brain of a given character
/// This object should have access to all relevant components of the character in order to process and execute various actions
/// </summary>
public abstract class CharacterBehaviour : MonoBehaviour, Damageable {

    /// <summary>
    /// The "intended" vector that the character wants to move
    /// </summary>
    protected Vector3 _walkVector;
    public Vector3 walkVector { get { return _walkVector; } }

    public enum BusyState {
        NONE, ATTACK, SKILL
    }
    [Flags] public enum Faction {
        PLAYER = 1 << 0,
        CIVILIAN = 1 << 1,
        MONSTER = 1 << 2,
        GUARD = 1 << 3, 
        OUTLAW = 1 << 4,
        CULTIST = 1 << 5
    }

    [SerializeField] protected BusyState _currentBusyState;
    public BusyState CurrentBusyState { get { return _currentBusyState; } }
    protected Coroutine busyRoutine;

    [SerializeField] protected Faction _faction;
    public Faction GetFaction { get { return _faction; } }

    [SerializeField] protected int _attackComboIndex = 0;
    public int AttackComboIndex { get { return _attackComboIndex; } }
    [SerializeField] protected Skill[] attackCombo;
    public Skill[] AttackCombo { get { return attackCombo; } }

    [SerializeField] protected Transform _bodyTransform;
    public Transform BodyTransform { get { return _bodyTransform; } }
    // where vision is calculated
    [SerializeField] protected Transform _head;
    public Transform Head { get { return _head; } }

    protected CharacterAnimationHandler animHandler;
    protected CharacterStats _stats;
    public CharacterStats stats { get { return _stats; } }

    protected virtual void Awake() {
        _currentBusyState = BusyState.NONE;
        _stats = GetComponent<CharacterStats>();
    }
    
    public virtual void TakeDamage(int damage) {
        Debug.Log(name + " has taken " + damage + " points of damage!");
    }

    protected virtual void Die() {

    }

    protected virtual void InitializeSkillSet() {

    }

    protected virtual void Attack() {

    }

    /// <summary>
    /// Disables other actions until the skill has been completed
    /// </summary>
    /// <param name="skill"></param>
    /// <returns></returns>
    protected virtual IEnumerator processAction(Skill skill, BusyState busyState) {
        skill.OnSkillStart(this);
        _currentBusyState = busyState;
        yield return new WaitForSeconds(skill.Duration);
        skill.OnSkillEnd(this);
        _currentBusyState = BusyState.NONE;
    }

    /// <summary>
    /// Disables other actions until this processingAction has been completed
    /// </summary>
    /// <param name="duration"></param>
    /// <returns></returns>
    protected virtual IEnumerator processAction(BusyState busyState, float duration) {
        _currentBusyState = busyState;
        yield return new WaitForSeconds(duration);
        _currentBusyState = BusyState.NONE;
    }
}
