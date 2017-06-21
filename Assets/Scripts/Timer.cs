using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    Stopwatch stopwatch = new Stopwatch();

    public int min, sec;
    
    TimeSpan limit;
    bool isStart = false;

    public TimeSpan LeftTime
    {
        get {
            var ret = limit - stopwatch.Elapsed;

            if (ret < TimeSpan.Zero) ret = TimeSpan.Zero;

            return ret;
        }
    }

    public bool IsEnd
    {
        get { return isStart && LeftTime <= TimeSpan.Zero; }
    }

	// Use this for initialization
	void Start () {
        limit = new TimeSpan(0,min,sec);
	}

    public void StartTimer() {
        if (!isStart)
        {
            stopwatch.Start();
            isStart = true;
        }
    }

}
