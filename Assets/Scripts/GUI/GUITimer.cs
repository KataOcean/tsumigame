using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUITimer : MonoBehaviour {

    private Timer timer;

    [SerializeField]
    private Text TimerText; 
    private TimeSpan HurryUp { get { return new TimeSpan( 0 , 0 , 10 ); } }

    public bool IsChangeColor = true;

	// Use this for initialization
	void Start () {
		
        if ( GameManager.Instance != null)
        {
            timer = GameManager.Instance.timer;
        }

        if (TimerText != null) TimerText.text = "";

	}

    private void OnGUI()
    {
        if ( timer != null && TimerText != null)
        {
            var left = timer.LeftTime;
            if ( IsChangeColor && left <= HurryUp) TimerText.color = Color.red;
            TimerText.text = string.Format("{0:00}'{1:00}\"{2:000}", left.Minutes, left.Seconds, left.Milliseconds);
        }
    }
}
