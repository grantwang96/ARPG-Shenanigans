using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardRebinder : MonoBehaviour {

    Event currentInput;
    private static bool waitingForButtonPress = false;

    public void BeginWaitingForKeyPress() {
        waitingForButtonPress = true;
    }

    public void Update() {
        DetectKeyPressed();
    }

    private void DetectKeyPressed() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            Debug.Log("TAB has been pressed");
        } else if (Input.GetKeyDown(KeyCode.Q)) {
            Debug.Log("Q has been pressed");
        } else if (Input.GetKeyDown(KeyCode.W)) {
            Debug.Log("W has been pressed");
        } else if (Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("E has been pressed");
        } else if (Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("R has been pressed");
        } else if (Input.GetKeyDown(KeyCode.T)) {
            Debug.Log("T has been pressed");
        } else if (Input.GetKeyDown(KeyCode.Y)) {
            Debug.Log("Y has been pressed");
        } else if (Input.GetKeyDown(KeyCode.U)) {
            Debug.Log("U has been pressed");
        } else if (Input.GetKeyDown(KeyCode.I)) {
            Debug.Log("I has been pressed");
        } else if (Input.GetKeyDown(KeyCode.O)) {
            Debug.Log("O has been pressed");
        } else if (Input.GetKeyDown(KeyCode.P)) {
            Debug.Log("P has been pressed");
        } else if (Input.GetKeyDown(KeyCode.LeftBracket)) {
            Debug.Log("[ has been pressed");
        } else if (Input.GetKeyDown(KeyCode.RightBracket)) {
            Debug.Log("] has been pressed");
        } else if (Input.GetKeyDown(KeyCode.CapsLock)) {
            Debug.Log("CAPS has been pressed");
        } else if (Input.GetKeyDown(KeyCode.A)) {
            Debug.Log("A has been pressed");
        } else if (Input.GetKeyDown(KeyCode.S)) {
            Debug.Log("S has been pressed");
        } else if (Input.GetKeyDown(KeyCode.D)) {
            Debug.Log("D has been pressed");
        } else if (Input.GetKeyDown(KeyCode.F)) {
            Debug.Log("F has been pressed");
        } else if (Input.GetKeyDown(KeyCode.G)) {
            Debug.Log("G has been pressed");
        } else if (Input.GetKeyDown(KeyCode.H)) {
            Debug.Log("H has been pressed");
        } else if (Input.GetKeyDown(KeyCode.J)) {
            Debug.Log("J has been pressed");
        } else if (Input.GetKeyDown(KeyCode.K)) {
            Debug.Log("K has been pressed");
        } else if (Input.GetKeyDown(KeyCode.L)) {
            Debug.Log("L has been pressed");
        } else if (Input.GetKeyDown(KeyCode.Semicolon)) {
            Debug.Log("; has been pressed");
        } else if (Input.GetKeyDown(KeyCode.Quote)) {
            Debug.Log("Quote has been pressed");
        } else if (Input.GetKeyDown(KeyCode.Return)) {
            Debug.Log("Enter has been pressed");
        } else if (Input.GetKeyDown(KeyCode.Q)) {
            Debug.Log("Q has been pressed");
        } else if (Input.GetKeyDown(KeyCode.Q)) {
            Debug.Log("Q has been pressed");
        } else if (Input.GetKeyDown(KeyCode.Q)) {
            Debug.Log("Q has been pressed");
        }
    }
}
