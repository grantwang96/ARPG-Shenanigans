using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : CharacterBehaviour, IVision {

    [SerializeField] protected int _health;
    public int Health;

    protected NPCBlueprint blueprint; // blueprint to derive data from
    protected BrainState currentBrainState; // current state of AI State Machine

    protected virtual void Start() {
        _health = blueprint.TotalHealth;
    }

    protected virtual void Update() {
        if(currentBrainState != null) { currentBrainState.Execute(); }
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

    public virtual void CheckVision() {
        // TODO: IMPLEMENT THIS FUNCTION
        Debug.Log("Looking now!");
    }

    public virtual bool CanSeeTarget() {
        // TODO: IMPLEMENT THIS FUNCTION
        return false;
    }
    
    public virtual bool DetectThreat() {
        // TODO: IMPLEMENT THIS FUNCTION
        return false;
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
}
