using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains information about actions characters use
/// </summary>
public abstract class Skill : ScriptableObject {

    [SerializeField] private AnimationClip _skillAnimation;
    public AnimationClip skillAnimation { get { return _skillAnimation; } }

    /// <summary>
    /// Receives a character behaviour to perform a skill
    /// </summary>
    public abstract void Use(CharacterBehaviour brain);
}
