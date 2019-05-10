using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
/**
 * Used to move enemies
 */
public class AI : MonoBehaviour {
    public GameObject player;
    private Rigidbody body;
    private float speed = Constants.ENEMY_SPEED;

    void Start () {
        body = GetComponent<Rigidbody>();
    }

    void Update () {
    	Vector3 velocity = Vector3.zero;
    	bool pause = Controller.pause;
    	// Move R-L
        if (player.transform.position.x > body.transform.position.x && !pause) {
            velocity += new Vector3(speed, 0, 0);
        }
        else if (player.transform.position.x < body.transform.position.x && !pause) {
            velocity += new Vector3(-speed, 0, 0);
        }
        // Move F-B
        if (player.transform.position.z > body.transform.position.z && !pause) {
            velocity += new Vector3(0, 0, speed);
        }
        else if (player.transform.position.z < body.transform.position.z && !pause) {
            velocity += new Vector3(0, 0, -speed);
        }

        body.velocity = velocity;
    }

    private void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Player") {
        	Renderer renderer = player.GetComponent<Renderer>();
        	renderer.material.color = Color.red;
        }
    }
}
