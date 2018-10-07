﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This acts as the player's "brain"
/// </summary>
public class PlayerInput : CharacterBehaviour {

    public static PlayerInput Instance;
    [SerializeField] private InputState inputState;
    public enum InputState {
        KeyboardMouse, Controller
    }

    private Vector3 _walkVector;
    public Vector3 walkVector { get { return _walkVector; } }
    private Vector2 _cameraVector;
    public Vector3 cameraVector { get { return _cameraVector; } }
    private float _cameraDistance = 3f;
    public float cameraDistance { get { return _cameraDistance; } }
    [SerializeField] private float scrollMultiplier = 1f;

    // these events don't need to pass in any extra information. Other classes will store info and handle.
    public delegate void CoreActionDelegate();
    public event CoreActionDelegate AttackEvent;
    public event CoreActionDelegate JumpEvent;
    
    protected override void Awake() {
        Instance = this;
        base.Awake();
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
        if (Input.GetButtonDown("Attack")) { AttackEvent.Invoke(); }
    }
    
    private void ControllerInput() {

    }
}
