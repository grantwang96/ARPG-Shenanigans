using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameplayController))]
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(CameraController))]
public class PlayerMovement : CharacterMoveController { // this class handles the player's movement
    
    private CameraController camCon;

    [SerializeField] private Transform body;
    [SerializeField] private Transform rightHandRoot;
    [SerializeField] private Transform leftHandRoot;
    
    [SerializeField] private float jumpForce; // the initial velocity of the player when jumping

    [SerializeField] private float lastAttackTime = 0;

    // component initialization
    public override void Awake() {
        base.Awake();
        camCon = GetComponent<CameraController>();
        movementVelocity.y = Physics.gravity.y;
    }

    // Use this for initialization
    public override void Start() {

    }
    
    private void OnEnable() {
        RegisterEventCallbacks();
    }

    private void OnDisable() {
        DeregisterEventCallbacks();
    }

    /// <summary>
    /// Registers all the callbacks for player actions (attack, jump, etc.)
    /// </summary>
    private void RegisterEventCallbacks() {
        Debug.Log("Registering player callback functions");
        GameplayController.Instance.AttackEvent += OnAttack;
        GameplayController.Instance.JumpEvent += OnJump;
    }

    /// <summary>
    /// Removes all callbacks for player actions
    /// </summary>
    private void DeregisterEventCallbacks() {
        Debug.Log("Deregistering player callback functions");
        GameplayController.Instance.AttackEvent -= OnAttack;
        GameplayController.Instance.JumpEvent -= OnJump;
    }

    protected override void FixedUpdate() {
        // Calculate the player's movement velocity
        ProcessGravity();
        ProcessPlayerInput();

        // move character controller at the end of loop
        characterController.Move(movementVelocity * Time.deltaTime);
    }

    /// <summary>
    /// Retrieves playerinput values in order to process how the player should move
    /// </summary>
    /// <returns></returns>
    private void ProcessPlayerInput() { // this produces the raw velocity of the player
        if (characterController.isGrounded) { movementVelocity = new Vector3(0f, movementVelocity.y, 0f); }
        if (GameplayController.Instance.CurrentBusyState != CharacterBehaviour.BusyState.NONE) { return; }
        Vector3 movementClamped =
            camCon.cameraAnchor.forward * characterBehaviour.walkVector.z + camCon.cameraAnchor.right * characterBehaviour.walkVector.x;
        body.forward = Vector3.Lerp(body.forward, movementClamped.normalized, 0.5f);
        movementVelocity = new Vector3(movementClamped.x * baseSpeed, movementVelocity.y, movementClamped.z * baseSpeed);
    }

    /// <summary>
    /// Event callback that makes the playerobject attack
    /// </summary>
    private void OnAttack() {
        Vector3 movementClamped =
            camCon.cameraAnchor.forward * characterBehaviour.walkVector.z + camCon.cameraAnchor.right * characterBehaviour.walkVector.x;
        body.forward = Vector3.Lerp(body.forward, movementClamped.normalized, 0.5f);
    }
    
    /// <summary>
    /// Event callback that makes the playerobject jump
    /// </summary>
    private void OnJump() {
        if (!characterController.isGrounded) { return; }
        movementVelocity.y = jumpForce;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if(hit.rigidbody != null) {
            hit.rigidbody.AddForce(characterController.velocity);
        }
    }
}
