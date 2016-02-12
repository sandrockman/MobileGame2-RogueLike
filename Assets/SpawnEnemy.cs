using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

    Rigidbody2D enemy;

	// Use this for initialization
	void Start () {
        InvokeRepeating("EnemySpawn", 3f, 3f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void EnemySpawn()
    {
        Rigidbody2D enemyInstance;

        enemyInstance = Instantiate(Resources.Load("Enemy"), new Vector3(Random.Range(2f, 8f), Random.Range(-4f, 4f), 0f), Quaternion.identity) as Rigidbody2D;
    }
}
