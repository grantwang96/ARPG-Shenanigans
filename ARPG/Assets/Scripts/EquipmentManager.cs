using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EquipmentManager : MonoBehaviour {

    // the anchors that hold the equipment
    [SerializeField] private Transform bodyCore;
    [SerializeField] private Transform rightHand;
    [SerializeField] private Transform leftHand;
    [SerializeField] private Transform rightFoot;
    [SerializeField] private Transform leftFoot;

    // todo: pass in equipment by "id" and attach to bodypart

}
