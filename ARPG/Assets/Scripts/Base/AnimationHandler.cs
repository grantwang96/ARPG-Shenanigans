using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour { // base class that handles animations

    public Animator anim;
    public Transform bodyCore;

    public AnimationCurve accelerationTiltCurve;
    public float tiltLimit;
    [SerializeField] private bool tiltEnabled;

    // temporary animation list
    public AnimationClip[] clips;
    public int clipIndex = 0;

    private void Start() {

    }
    
    public virtual void TiltCharacter(float x) {
        if (!tiltEnabled) { return; }
        float val = Mathf.Clamp(x, -1, 1);
        // int mod = x > 0 ? 1 : -1;
        // float val = Mathf.Abs(accelerationTiltCurve.Evaluate(x));
        bodyCore.localEulerAngles = new Vector3(
            bodyCore.localEulerAngles.x, bodyCore.localEulerAngles.y, -val * tiltLimit);
    }
}
