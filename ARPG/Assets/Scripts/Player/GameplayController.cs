using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This acts as the player's "brain"
/// </summary>
public class GameplayController : CharacterBehaviour {

    public static GameplayController Instance;
    [SerializeField] private InputState inputState;
    public enum InputState {
        KeyboardMouse, Controller
    }

    protected Vector2 _cameraVector;
    public Vector3 cameraVector { get { return _cameraVector; } }
    protected float _cameraDistance = 3f;
    public float cameraDistance { get { return _cameraDistance; } }
    [SerializeField] private float scrollMultiplier = 1f;

    // these events don't need to pass in any extra information. Other classes will store info and handle.
    public delegate void CoreActionDelegate();
    public delegate void SkillActionDelegate();

    public event CoreActionDelegate JumpEvent;
    public event CoreActionDelegate AttackEvent;

    public event CoreActionDelegate DodgeEvent;
    public event CoreActionDelegate DefendEvent;
    
    protected override void Awake() {
        Instance = this;
        base.Awake();
        animHandler = GetComponent<CharacterAnimationHandler>();
    }

    // Use this for initialization
    protected override void Start () {
        base.Start();
		if(inputState == InputState.KeyboardMouse) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
	}
	
	// Update is called once per frame
	protected override void Update () {
        switch (inputState) {
            case InputState.KeyboardMouse:
                MouseNKeyboardInput();
                break;
            case InputState.Controller:
                ControllerInput();
                break;
        }
	}

    protected override void InitializeSkillSet() {
        base.InitializeSkillSet();
    }

    private void MouseNKeyboardInput() {
        // directional movement input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        _walkVector = new Vector3(horizontal, 0, vertical);

        // camera control input
        float camX = Input.GetAxis("Mouse X");
        float camY = Input.GetAxis("Mouse Y");
        _cameraVector = new Vector3(camX, camY);

        _cameraDistance -= Input.GetAxis("Mouse ScrollWheel") * scrollMultiplier;
        _cameraDistance = Mathf.Clamp(_cameraDistance, 1f, 10f);

        if (Input.GetButtonDown("Jump")) { JumpEvent.Invoke(); }
        if (Input.GetButtonDown("Attack")) { Attack(); }
    }
    
    private void ControllerInput() {

    }

    protected override void Attack() {
        // check if player is already attacking
        bool isAttacking = animHandler.IsStateByTag("Attack"); // REFACTOR: Use BusyState instead
        if (!canInitiateAttack(isAttacking)) { return; }
        CalculateAttackComboIndex(isAttacking);
        AttackEvent.Invoke();
        if(CurrentBusyState == BusyState.ATTACK || CurrentBusyState == BusyState.NONE) {
            if(busyRoutine != null) { StopCoroutine(busyRoutine); }
            busyRoutine = StartCoroutine(processAction(attackCombo[AttackComboIndex], BusyState.ATTACK));
        }
    }

    private void CalculateAttackComboIndex(bool isAttacking) {
        if (!isAttacking) { _attackComboIndex = 0; return; }
        if (animHandler.anim.GetInteger("AttackComboIndex") == AttackComboIndex) {
            _attackComboIndex++;
            if (_attackComboIndex >= attackCombo.Length) { _attackComboIndex = 0; }
        }
    }

    private bool canInitiateAttack(bool isAttacking) {
        // WIP: DO NOT MAKE TRANSITION ALLOWED TIME ARBITRARY NUMBER
        if ((isAttacking && animHandler.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.33f
            && AttackComboIndex < attackCombo.Length - 1)
            || CurrentBusyState == BusyState.NONE) {
            return true;
        }
        return false;
    }
}
