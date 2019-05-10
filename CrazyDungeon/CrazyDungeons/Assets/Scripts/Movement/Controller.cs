using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
/**
 * Used to game controllers
 * @type {[type]}
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

    public Transform cinemachinePos;
    public float dashforce = Constants.DASHFORCE;
    int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    float camRayLength = 100f;

    void Start() {
        body = GetComponent<Rigidbody>();
        textMenu = GameObject.FindWithTag("Menu");
        textMenu.GetComponent<Renderer>().enabled = false;
    }

    void Update() {
        /*Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            Debug.Log("hit");
            Vector3 playerToMouse = hit.point - transform.position;
            
            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            //Debug.DrawRay(Camera.main.transform.position, camRay.direction, Color.green, 10000);
            // Set the player's rotation to this new rotation.
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = hit.point;
      
            body.MoveRotation(newRotation);
        }*/
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
            newSpeed *= speed;
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

    private void FixedUpdate() {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(camRay, out hit)) {
            Vector3 playerToMouse = hit.point - transform.position;
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            Debug.DrawRay(hit.point, Camera.main.transform.forward, Color.green, 10000);

            body.MoveRotation(newRotation);
        }
    }

    public void OnTriggerEnter(Collider other) {
        //if (other.tag == "") {
            Console.Log.Print(other.tag);
        //}
    }
}
