﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class HumanoidMoveController : GravCharMoveController {

    [SerializeField] protected CharacterController charCon;
}