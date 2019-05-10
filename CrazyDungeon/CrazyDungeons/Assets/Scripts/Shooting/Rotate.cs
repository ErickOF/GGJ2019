using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public GameObject player;
    private Vector3 NewPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* NewPos = this.transform.localEulerAngles;
        this.transform.localEulerAngles = new Vector3(0, 0, 0);
        player.transform.localEulerAngles = NewPos;*/


        Vector3 v3T = Input.mousePosition;
        v3T.z = Mathf.Abs(Camera.main.transform.position.y - transform.position.y);
        v3T.z = this.transform.position.y;
        v3T = Camera.main.ScreenToWorldPoint(v3T);
        transform.LookAt(v3T);
       // transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
    }
}
