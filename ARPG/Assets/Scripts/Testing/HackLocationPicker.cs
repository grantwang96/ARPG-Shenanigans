using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackLocationPicker : MonoBehaviour {

    public LayerMask environmentMask;

    public NPCBehaviour targetEnemy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.forward, out hit, 50f, environmentMask)){
                Debug.Log("HACK: Selected target point: " + hit.point);
                targetEnemy.HACKSetDestination(hit.point);
            }
        }
	}
}
