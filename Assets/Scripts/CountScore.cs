using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CountScore : MonoBehaviour {

    [SerializeField]
    GameObject Root;

    public Score Count( Score score )
    {

        score.Value = Root.GetComponentsInChildren<CheckStop>().Count( x => x.isStop  );

        return score;

    }

}
