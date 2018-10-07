using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// The brain of a given character
/// This object should have access to all relevant components of the character in order to process and execute various actions
/// </summary>
[RequireComponent(typeof(Damageable))]
public abstract class CharacterBehaviour : MonoBehaviour {

    protected Damageable myDamageable;
    protected AnimationHandler animHandler;
    protected CharacterStats _stats;
    public CharacterStats stats { get { return _stats; } }

    protected virtual void Awake() {
        myDamageable = GetComponent<Damageable>();
        animHandler = GetComponent<AnimationHandler>();
        _stats = GetComponent<CharacterStats>();
    }

	// Use this for initialization
	protected virtual void Start () {
        
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		
	}
}
