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

    private void OnEnable() {
        if (gameObject == PlayerInput.Instance.gameObject) {
            PlayerInput.Instance.Attack += OnAttack;
            PlayerInput.Instance.Jump += OnJump;
        }
    }

    private void OnDisable() {
        if (gameObject == PlayerInput.Instance.gameObject) {
            PlayerInput.Instance.Attack -= OnAttack;
            PlayerInput.Instance.Jump -= OnJump;
        }
    }

    public virtual void TiltCharacter(float x) {
        if (!tiltEnabled) { return; }
        float val = Mathf.Clamp(x, -1, 1);
        // int mod = x > 0 ? 1 : -1;
        // float val = Mathf.Abs(accelerationTiltCurve.Evaluate(x));
        bodyCore.localEulerAngles = new Vector3(
            bodyCore.localEulerAngles.x, bodyCore.localEulerAngles.y, -val * tiltLimit);
    }

    // WIP: separate into multiple functions
    private void OnAttack() {
        if (gameObject == PlayerInput.Instance.gameObject) {
            AnimatorOverrideController aoc = new AnimatorOverrideController(anim.runtimeAnimatorController);
            var animClips = new List<KeyValuePair<AnimationClip, AnimationClip>>();
            int clipIndexOld = clipIndex;
            clipIndex++;
            aoc.name = "Override" + clipIndex;
            if (clipIndex >= clips.Length) { clipIndex = 0; }
            float time = 0f;
            foreach(AnimationClip a in aoc.animationClips) {
                AnimationClip clip = a;
                if(a == clips[clipIndexOld]) { clip = clips[clipIndex]; time = clip.length; }
                animClips.Add(new KeyValuePair<AnimationClip, AnimationClip>(a, clip));
            }
            aoc.ApplyOverrides(animClips);
            anim.runtimeAnimatorController = aoc;
            anim.Play("Attack");
            Debug.Log("Attack time: " + time);
        }
    }

    private void OnJump() {

    }
}
