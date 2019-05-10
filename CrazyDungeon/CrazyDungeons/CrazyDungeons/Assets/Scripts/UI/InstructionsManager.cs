using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsManager : MonoBehaviour {
	// Keys
    public KeyCode EXIT = KeyCode.Escape;
    public KeyCode BACK = KeyCode.Backspace;

    void Start() {
    }

    void Update() {
        if (Input.GetKey(EXIT)) {
	        Application.Quit();
        }
        if (Input.GetKey(BACK)) {
	        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }
}
