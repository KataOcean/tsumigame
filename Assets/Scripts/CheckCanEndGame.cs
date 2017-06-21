using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CheckCanEndGame : MonoBehaviour {

    [SerializeField]
    GameObject Root;

    public bool canEnd
    {
        get {

            return (timer >= 1.0f);
            
        }

    }

    float timer = 0.0f;

    private void Update()
    {

        if ((Root.GetComponentsInChildren<CheckStop>().Count(b => !b.isStop) == 0))
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0.0f;
        }

    }
}
