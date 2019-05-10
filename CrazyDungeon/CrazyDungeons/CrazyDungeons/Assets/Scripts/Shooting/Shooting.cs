using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    // Use this for initialization
    public GameObject shootingpoint;
    public GameObject Bullet;
    public float bulletSpeed=100;
    public float range = 1;

    public float  firerate = 1;
    private float timer;
    void Start () {
        timer = firerate;

    }

// Update is called once per frame
void Update () {

        timer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse1)&& timer <= 0)
        {

            Shoot();
            timer = firerate;
        }

    }


    void Shoot()
    {
        Vector3 spawnPos = this.transform.position + this.transform.forward * 0.5f;
        GameObject go = Instantiate(Bullet, spawnPos, this.transform.rotation) as GameObject;

        go.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);

    }

}
