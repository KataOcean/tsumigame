using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIScore : MonoBehaviour {

    [SerializeField]
    Text ScoreText;

    string scoreString {
        get {

            if (GameManager.Instance == null || GameManager.Instance.score == null) return "";
            else
            {
                return GameManager.Instance.score.GetScoreString;
            }

        }
    }

	// Use this for initialization
	void Start () {
        if (ScoreText != null) ScoreText.text = "";
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
