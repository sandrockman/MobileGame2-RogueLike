using UnityEngine;
using System.Collections;

public class OrbDestroy : MonoBehaviour {

    public float destroyTime = 1.0f;
	// Use this for initialization
	void Start () {
        StartCoroutine(Boom());
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Boom()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}
