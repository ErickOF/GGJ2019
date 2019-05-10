using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private float timer=5;
    public int numberBounces = 2;
    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
               Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (numberBounces < 0)
        Destroy(gameObject);

        timer = 5;
        numberBounces--;
    }
}
