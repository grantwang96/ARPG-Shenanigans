using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(CameraController))]
public class PlayerMovement : CharacterMoveController { // this class handles the player's movement

    private PlayerInput playerInput;
    private CharacterController charCon;
    private CameraController camCon;

    [SerializeField] private Transform body;
    [SerializeField] private Transform rightHandRoot;
    [SerializeField] private Transform leftHandRoot;

    [SerializeField] private Vector3 movementVelocity;
    [SerializeField] private float jumpForce; // the initial velocity of the player when jumping

    // component initialization
    public override void Awake() {
        playerInput = GetComponent<PlayerInput>();
        charCon = GetComponent<CharacterController>();
        camCon = GetComponent<CameraController>();
        movementVelocity.y = Physics.gravity.y;
    }

    // Use this for initialization
    public override void Start() {
        
    }
    
    private void OnEnable() {
        RegisterEventCallbacks();
    }

    /// <summary>
    /// Registers all the callbacks for player actions (attack, jump, etc.)
    /// </summary>
    private void RegisterEventCallbacks() {
        Debug.Log("Registering player callback functions");
        PlayerInput.Instance.Attack += OnAttack;
        PlayerInput.Instance.Jump += OnJump;
    }

    /// <summary>
    /// Removes all callbacks for player actions
    /// </summary>
    private void DeRegisterEventCallbacks() {
        Debug.Log("Deregistering player callback functions");
        PlayerInput.Instance.Attack -= OnAttack;
        PlayerInput.Instance.Jump -= OnJump;
    }

    private void FixedUpdate() {
        // Calculate the player's movement velocity
        ProcessGravity();
        ProcessPlayerInput();

        // move character controller at the end of loop
        charCon.Move(movementVelocity * Time.deltaTime);
    }

    /// <summary>
    /// Retrieves playerinput values in order to process how the player should move
    /// </summary>
    /// <returns></returns>
    private void ProcessPlayerInput() { // this produces the raw velocity of the player
        Vector3 movementClamped =
            camCon.cameraAnchor.forward * playerInput.walkVector.z + camCon.cameraAnchor.right * playerInput.walkVector.x;
        movementVelocity = new Vector3(movementClamped.x * baseSpeed, movementVelocity.y, movementClamped.z * baseSpeed);
        body.forward = Vector3.Lerp(body.forward, movementClamped.normalized, 0.5f);
    }

    private void ProcessGravity() {
        if (movementVelocity.y > Physics.gravity.y) {
            movementVelocity.y += Time.deltaTime * Physics.gravity.y;
        }
    }

    /// <summary>
    /// Event callback that makes the playerobject attack
    /// </summary>
    private void OnAttack() {
        // Debug.Log("Attack!");
    }

    /// <summary>
    /// Event callback that makes the playerobject jump
    /// </summary>
    private void OnJump() {
        if (!charCon.isGrounded) { return; }
        movementVelocity.y = jumpForce;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        
    }
}
