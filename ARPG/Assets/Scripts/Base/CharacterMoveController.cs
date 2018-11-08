using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class CharacterMoveController : MonoBehaviour { // Handles character movement

    [SerializeField] protected float baseSpeed;
    [SerializeField] protected bool _performingAction;
    public bool performingAction { get { return _performingAction; } }

    protected CharacterBehaviour characterBehaviour; // gain read access from character's brain
    protected CharacterController characterController; // accesses the character controller on the character

    protected Coroutine busyAnimation; // coroutine that prevents other actions from being taken

    public virtual void Awake() {
        characterBehaviour = GetComponent<CharacterBehaviour>();
        characterController = GetComponent<CharacterController>();
    }

    public virtual void Start() {

    }

    public virtual void Update() {
        
    }
}
