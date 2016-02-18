using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    Text scoreBox;
    float score;

    Text shotsBox;
    float shots;

	// Use this for initialization
	void Start () {
        score = 0;
        shots = 0;
        scoreBox = GameObject.Find("ScoreText").GetComponent<Text>();
        shotsBox = GameObject.Find("NumShotsText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {
	
	}

    void AddTime()
    {
        score += 0.5f;
        scoreBox.text = string.Format("Score: {0}", System.Math.Round(score, 1));
    }
}
