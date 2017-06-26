<<<<<<< HEAD
﻿using System;
using System.Collections;
=======
﻿using System.Collections;
>>>>>>> aa04006b3c856edd0d120567cf630f3f39ac354d
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUITimer : MonoBehaviour {

    private Timer timer;

    [SerializeField]
<<<<<<< HEAD
    private Text TimerText; 
    private TimeSpan HurryUp { get { return new TimeSpan( 0 , 0 , 10 ); } }

    public bool IsChangeColor = true;
=======
    private Text TimerText;
>>>>>>> aa04006b3c856edd0d120567cf630f3f39ac354d

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
<<<<<<< HEAD
            if ( IsChangeColor && left <= HurryUp) TimerText.color = Color.red;
=======
>>>>>>> aa04006b3c856edd0d120567cf630f3f39ac354d
            TimerText.text = string.Format("{0:00}'{1:00}\"{2:000}", left.Minutes, left.Seconds, left.Milliseconds);
        }
    }
}
