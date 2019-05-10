using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
/**
 * Used to follow the main character
 */
public class Follower : MonoBehaviour {
    public Vector3 displacement = Vector3.zero;
    public Vector3 rotation = Vector3.zero;
    public Transform objective;

    void Start() {
    	transform.Rotate(rotation.x, rotation.y, rotation.z);
    }

    void Update() {
        transform.position = objective.position + displacement;
    }
}
