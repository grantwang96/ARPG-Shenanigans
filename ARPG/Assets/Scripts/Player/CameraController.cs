using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    float upDownLook = 0f;
    [SerializeField] private float upDownLookLimit = 80f;
    public float mouseSensitivity;
    [SerializeField] Transform _cameraAnchor;
    public Transform cameraAnchor { get { return _cameraAnchor; } }
    [SerializeField] Transform cameraPivot;
    [SerializeField] Camera cam;

    [SerializeField] private bool correctCameraDist;
    public LayerMask cameraCollide;
    public float collisionOffset;

    public enum TrackingMode {
        Free, RearLock
    }
    [SerializeField] private TrackingMode trackingMode;

    public AnimationHandler animHandler;

    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
        processMouseMovement(); // handle mouse movement
        CameraDistanceCorrector();
    }

    private void processMouseMovement() {
        // 1. get mouse input data
        // float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity; // horizontal mousespeed
        // float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity; // vertical mousespeed
        float mouseX = PlayerInput.Instance.cameraVector.x * Time.deltaTime * mouseSensitivity; // horizontal mousespeed
        float mouseY = PlayerInput.Instance.cameraVector.y * Time.deltaTime * mouseSensitivity; // vertical mousespeed

        animHandler.TiltCharacter(mouseX);

        upDownLook -= mouseY; // minus-equals un-inverts the mouse-look-y
        upDownLook = Mathf.Clamp(upDownLook, -upDownLookLimit, upDownLookLimit); // constrain look 80 degrees up or down

        // Body.Rotate(0f, mouseX, 0f);

        switch(trackingMode) {
            case TrackingMode.Free:
                FreeRotate(mouseX);
                break;
            case TrackingMode.RearLock:
                RearLockRotate(mouseX);
                break;
            default:
                FreeRotate(mouseX);
                break;
        }
    }

    private void FreeRotate(float mouseX) {
        cameraPivot.localEulerAngles = new Vector3(upDownLook, cameraPivot.localEulerAngles.y, 0f);
        Vector3 bodyTurn = cameraPivot.eulerAngles + new Vector3(0, mouseX, 0);
        cameraPivot.eulerAngles = bodyTurn;
    }

    private void RearLockRotate(float mouseX) {
        cameraPivot.localEulerAngles = new Vector3(upDownLook, 0f, 0f);
        _cameraAnchor.eulerAngles = _cameraAnchor.eulerAngles + new Vector3(0, mouseX, 0);
        // transform.localEulerAngles = bodyTurn;
        // _cameraAnchor.localEulerAngles = bodyTurn;
    }

    private void CameraDistanceCorrector() {
        cam.transform.localPosition =
            Vector3.back * Mathf.Lerp(cam.transform.localPosition.magnitude, PlayerInput.Instance.cameraDistance, 0.3f);
        if (!correctCameraDist) { return; }
        RaycastHit rayHit;
        if(Physics.Raycast(
            new Ray(cameraPivot.position, -cameraPivot.forward), out rayHit, PlayerInput.Instance.cameraDistance, cameraCollide, QueryTriggerInteraction.Ignore))
        {
            cam.transform.localPosition = Vector3.back * (rayHit.distance - collisionOffset);
        }
    }
}
