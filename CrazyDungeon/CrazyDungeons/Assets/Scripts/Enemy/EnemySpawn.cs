using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    // Start is called before the first frame update
	int numEnemies=1;
	private RoomTemplates templates;

    void Start() {
    	templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
    }

    private void OnCollisionEnter(Collision collisionInfo){
    	int randonEnemyNumber = Random.Range(0,templates.enemyList.lenght);
    	GameObject enemy = templates.enemyList.get(randonEnemyNumber);
    	Instantiate(enemy, transform.position,transform.rotation);
    }

    // Update is called once per frame
    public void Update() {   
    }

    public void Spawn(){
    }
}
