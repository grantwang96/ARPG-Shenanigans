using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "TestScript/Foo")]
public class TestScript : ScriptableObject {

    public static TestScript Instance;

    public Transform foo;
    public Transform[] foos;

    private void OnEnable() {
        // Instance = this;
        // Debug.Log("Test Script enabled!");
    }
}
