using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByLine : MonoBehaviour {

    [SerializeField]
    Transform DeadLine;

	// Use this for initialization
	void Start () {
        DeadLine = GameObject.Find( "DeadLine" ).transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < DeadLine.position.y) Destroy( gameObject );
    }
}
