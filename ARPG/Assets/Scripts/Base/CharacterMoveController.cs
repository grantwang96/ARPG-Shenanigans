using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class CharacterMoveController : MonoBehaviour { // Handles character movement

    [SerializeField] protected float baseSpeed;
    [SerializeField] protected bool _performingAction;
    public bool performingAction { get { return _performingAction; } }

    public virtual void Awake() {

    }

    public virtual void Start() {

    }

    public virtual void Update() {
        
    }
}
