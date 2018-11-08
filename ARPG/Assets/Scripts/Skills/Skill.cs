using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains information about actions characters use
/// </summary>
public abstract class Skill : ScriptableObject {

    [SerializeField] private AnimationClip _skillAnimation;
    public virtual AnimationClip skillAnimation { get { return _skillAnimation; } }
    public virtual float Duration {
        get {
            float animationDuration = skillAnimation != null ? skillAnimation.length : 0f;
            return animationDuration;
        }
    }

    /// <summary>
    /// Receives a character behaviour to perform a skill
    /// </summary>
    public abstract void Use(CharacterBehaviour brain);

    /// <summary>
    /// Action that occurs at the start of the skill
    /// </summary>
    public abstract void OnSkillStart(CharacterBehaviour brain);

    /// <summary>
    /// Action that occurs at the end of the skill
    /// </summary>
    public abstract void OnSkillEnd(CharacterBehaviour brain);
}
