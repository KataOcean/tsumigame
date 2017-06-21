using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CountScore : MonoBehaviour {

    [SerializeField]
    GameObject Root;

    public Score Count( Score score )
    {

        score.Value = Root.GetComponentsInChildren<Transform>().Count( x => x != Root.transform );

        return score;

    }

}
