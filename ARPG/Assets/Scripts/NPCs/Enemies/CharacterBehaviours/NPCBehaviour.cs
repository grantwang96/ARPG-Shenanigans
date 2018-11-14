using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCBehaviour : CharacterBehaviour, IVision {

    [SerializeField] protected int _health;
    public int Health;

    [SerializeField] protected NPCBlueprint blueprint; // blueprint to derive data from
    public NPCBlueprint Blueprint { get { return blueprint; } }
    protected BrainState currentBrainState; // current state of AI State Machine

    // where vision is calculated
    [SerializeField] protected Transform _head;
    public Transform Head { get { return _head; } }

    // where pathfinding is handled (do not allow agent to move character)
    [SerializeField] protected NavMeshAgent _agent;
    public NavMeshAgent Agent { get { return _agent; } }

    // characters this NPC is aware of
    protected List<CharacterBehaviour> knownCharacters = new List<CharacterBehaviour>();

    protected override void Awake() {
        base.Awake();
        _agent = GetComponent<NavMeshAgent>();
        _agent.updatePosition = false;
        _agent.updateRotation = false;
    }

    protected virtual void Start() {
        if(blueprint == null) {
            Debug.LogError(name + " doesn't have a blueprint!");
            return;
        }
        _health = blueprint.TotalHealth;
    }

    protected virtual void Update() {
        if(currentBrainState != null) { currentBrainState.Execute(); }
        if (Input.GetKeyDown(KeyCode.K)) { IsThreat(GameplayController.Instance); }
    }

    /// <summary>
    /// Changes the current state in the AI State Machine
    /// </summary>
    /// <param name="brainState"></param>
    public virtual void ChangeBrainState(BrainState brainState) {
        // perform any exit operations from the previous state
        if (currentBrainState != null) { currentBrainState.Exit(); }

        // save the new brain state and enter
        currentBrainState = brainState;
        currentBrainState.Enter(this);
    }

    /// <summary>
    /// If a character has been seen, this NPC should react accordingly
    /// </summary>
    /// <param name="behaviour"></param>
    protected virtual void ReactToCharacter(CharacterBehaviour behaviour) {

    }

    public virtual void CheckVision() {
        // TODO: IMPLEMENT THIS FUNCTION
        foreach(CharacterBehaviour character in knownCharacters) {

        }
    }

    public virtual bool CanSeeTarget() {
        // TODO: IMPLEMENT THIS FUNCTION
        return false;
    }
    
    public virtual bool DetectThreat() {
        // TODO: IMPLEMENT THIS FUNCTION
        return false;
    }

    protected virtual bool IsThreat(CharacterBehaviour behaviour) {
        Faction otherFaction = behaviour.GetFaction;
        // use bitwise operation & to check if otherFaction is any of these potential threats
        Debug.Log((otherFaction & (Faction.MONSTER | Faction.CULTIST | Faction.OUTLAW)) != 0);
        return (otherFaction & (Faction.MONSTER | Faction.CULTIST | Faction.OUTLAW)) != 0;
    }

    public virtual void RegisterCharacterBehaviour(CharacterBehaviour characterBehaviour) {
        if (!knownCharacters.Contains(characterBehaviour)) {
            knownCharacters.Add(characterBehaviour);
        }
    }

    public virtual void DeregisterCharacterBehaviour(CharacterBehaviour characterBehaviour) {
        if (knownCharacters.Contains(characterBehaviour)) {
            knownCharacters.Remove(characterBehaviour);
        }
    }
}

/// <summary>
/// Interface that allows NPCs to check for vision
/// </summary>
public interface IVision {
    // WIP: these should return values
    
    void CheckVision(); // checks general vision and returns first custom object it sees
    bool CanSeeTarget(); // checks to see if NPC's target is still viewable(if it has one)
    bool DetectThreat(); // checks for potential threat. Probably saves that info
    void RegisterCharacterBehaviour(CharacterBehaviour characterBehaviour);
    void DeregisterCharacterBehaviour(CharacterBehaviour characterBehaviour);
}
