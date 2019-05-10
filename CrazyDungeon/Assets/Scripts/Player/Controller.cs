using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
/**
 * Used to game controllers
 */
public class Controller : MonoBehaviour {
	// Keys definitions
    public KeyCode FOWARD;
    public KeyCode BACK;
    public KeyCode LEFT;
    public KeyCode RIGHT;
    public KeyCode UP_SPEED;
    public KeyCode PAUSE;

    public float speed = Constants.PLAYER_SPEED;
    private Rigidbody body;
    private GameObject textMenu;
    public static bool pause = false;
    public static bool pausePressed = false;
    private bool upSpeed = true;

    void Start() {
        body = GetComponent<Rigidbody>();
        textMenu = GameObject.FindWithTag("Menu");
        textMenu.GetComponent<Renderer>().enabled = false;
    }

    void Update() {
        Vector3 newSpeed = Vector3.zero;
        // Move character
        if (Input.GetKey(FOWARD) && !pause) {
        	newSpeed += new Vector3(0, 0, speed);
        }
        if (Input.GetKey(BACK) && !pause) {
            newSpeed += new Vector3(0, 0, -speed);
        }
        if (Input.GetKey(RIGHT) && !pause) {
            newSpeed += new Vector3(speed, 0, 0);
        }
        if (Input.GetKey(LEFT) && !pause) {
            newSpeed += new Vector3(-speed, 0, 0);
        }
        // Up speed
        if (Input.GetKeyDown(UP_SPEED) && upSpeed && !pause) {
        	newSpeed *= Constants.UP_SPEED;
        	upSpeed = false;
        }
        if (Input.GetKeyUp(UP_SPEED) && !upSpeed && !pause) {
        	upSpeed = !upSpeed;
        }
        // Pause
        if (Input.GetKeyDown(PAUSE) && !pausePressed) {
        	pause = !pause;
        	pausePressed = !pausePressed;
        	textMenu.GetComponent<Renderer>().enabled = pause;
        }
        if (Input.GetKeyUp(PAUSE) && pausePressed) {
        	pausePressed = !pausePressed;
        }

        // Set speed
        body.velocity = newSpeed;
    }
}
