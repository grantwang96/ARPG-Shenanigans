using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanner : MonoBehaviour {

    private Vector2 move;
    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");

        transform.position += new Vector3(move.x, 0, move.y) * speed * Time.deltaTime;
	}
}
