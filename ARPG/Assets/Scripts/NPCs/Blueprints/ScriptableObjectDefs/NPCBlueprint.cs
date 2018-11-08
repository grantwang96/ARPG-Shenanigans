using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPCBlueprint : ScriptableObject {

    [SerializeField] protected int _totalHealth;
    public int TotalHealth { get { return _totalHealth; } }
    [SerializeField] protected float _walkSpeed;
    public float WalkSpeed { get { return _walkSpeed; } }
    [SerializeField] protected float _runSpeed;
    public float RunSpeed { get { return _runSpeed; } }

    [SerializeField] private float _idleTimeMinimum;
    public float IdleTimeMinimum { get { return _idleTimeMinimum; } }
    [SerializeField] private float _idleTimeMaximum;
    public float IdleTimeMaximum { get { return _idleTimeMaximum; } }

    public virtual void OnIdleEnter(NPCBehaviour npc) {

    }
    public virtual void OnIdleExecute(NPCBehaviour npc) {

    }
    public virtual void OnIdleExit(NPCBehaviour npc) {

    }
}
