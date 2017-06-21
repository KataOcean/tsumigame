using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CheckStop : MonoBehaviour {

    public bool isStop { get; private set; }
    Rigidbody2D body;

	// Use this for initialization
	void Start () {
        isStop = false;
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        isStop = Mathf.Abs(body.velocity.y) <= 1.0f;

	}
}
