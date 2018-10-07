using System;
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

    [SerializeField] private Animator anim;

    [SerializeField] private Transform body;
    [SerializeField] private Transform rightHandRoot;
    [SerializeField] private Transform leftHandRoot;

    [SerializeField] private Vector3 movementVelocity;
    [SerializeField] private float jumpForce; // the initial velocity of the player when jumping

    [SerializeField] private List<Skill> attackString = new List<Skill>();
    [SerializeField] private int _attackStringIndex = 0;
    [SerializeField] private float lastAttackTime = 0;

    // component initialization
    public override void Awake() {
        playerInput = GetComponent<PlayerInput>();
        charCon = GetComponent<CharacterController>();
        camCon = GetComponent<CameraController>();
        movementVelocity.y = Physics.gravity.y;
    }

    // Use this for initialization
    public override void Start() {
        _attackStringIndex = attackString.Count - 1;
    }
    
    private void OnEnable() {
        RegisterEventCallbacks();
    }

    /// <summary>
    /// Registers all the callbacks for player actions (attack, jump, etc.)
    /// </summary>
    private void RegisterEventCallbacks() {
        Debug.Log("Registering player callback functions");
        PlayerInput.Instance.AttackEvent += OnAttack;
        PlayerInput.Instance.JumpEvent += OnJump;
    }

    /// <summary>
    /// Removes all callbacks for player actions
    /// </summary>
    private void DeRegisterEventCallbacks() {
        Debug.Log("Deregistering player callback functions");
        PlayerInput.Instance.AttackEvent -= OnAttack;
        PlayerInput.Instance.JumpEvent -= OnJump;
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

        if (performingAction) { return; }

        int clipIndexOld = SelectAttack();
        Skill currentSkill = attackString[_attackStringIndex];
        float animationLength = 0f;
        animationLength = currentSkill.skillAnimation.length;

        OverrideAnimator("Attack", attackString[clipIndexOld].skillAnimation, attackString[_attackStringIndex].skillAnimation);

        anim.Play("Attack");
        lastAttackTime = Time.time;
        StartCoroutine(processAction(animationLength, currentSkill));
    }

    private int SelectAttack() {
        int clipIndexOld = _attackStringIndex;
        if(Time.time - lastAttackTime > 1f) {
            _attackStringIndex = 0;
        } else {
            clipIndexOld = _attackStringIndex;
            _attackStringIndex++;
            if (_attackStringIndex >= attackString.Count) { _attackStringIndex = 0; }
        }
        return clipIndexOld;
    }

    private void OverrideAnimator(string stateName, AnimationClip toBeOverridden, AnimationClip newClip) {

        AnimatorOverrideController aoc = new AnimatorOverrideController(anim.runtimeAnimatorController);
        var animClips = new List<KeyValuePair<AnimationClip, AnimationClip>>();

        foreach (AnimationClip a in aoc.animationClips) {
            AnimationClip clip = a;
            if (a == toBeOverridden) {
                clip = newClip;
            }
            animClips.Add(new KeyValuePair<AnimationClip, AnimationClip>(a, clip));
        }
        aoc.ApplyOverrides(animClips);
        anim.runtimeAnimatorController = aoc;
    }

    private IEnumerator processAction(float animationTime, Skill skill) {
        Debug.Log("Animation Time" + animationTime);
        skill.OnSkillStart(PlayerInput.Instance);
        _performingAction = true;
        yield return new WaitForSeconds(animationTime);
        skill.OnSkillEnd(PlayerInput.Instance);
        _performingAction = false;
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
