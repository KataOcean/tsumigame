using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIScore : MonoBehaviour {

    [SerializeField]
    Text ScoreText;
    int EndScore;
    string scoreString {
        get {

            return EndScore + " Box";

        }
    }

	// Use this for initialization
	void Start () {
        if (ScoreText != null) ScoreText.text = "";
        if (GameManager.Instance != null && GameManager.Instance.score != null){
            EndScore = GameManager.Instance.score.Value;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
        if ( ScoreText != null)
        {
            ScoreText.text = scoreString;
        }
    }
}
