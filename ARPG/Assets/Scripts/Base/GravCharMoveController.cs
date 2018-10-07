using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravCharMoveController : CharacterMoveController {

    [SerializeField] protected bool isGrounded;
    [SerializeField] protected float gravity;
}
