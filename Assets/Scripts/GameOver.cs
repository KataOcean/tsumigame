using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    Timer timer;

    [SerializeField]
    List<MonoBehaviour> stopScripts;

	// Use this for initialization
	void Start () {
		
        if ( GameManager.Instance != null)
        {

            timer = GameManager.Instance.timer;

        }

	}
	
	// Update is called once per frame
	void Update () {
		
        if ( timer.IsEnd)
        {
            foreach (var scr in stopScripts) scr.enabled = false;
            enabled = false;
        }

	}
}
