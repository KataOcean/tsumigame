using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerController : MonoBehaviour {

    SpriteRenderer lazer;
    
    [SerializeField]
    private LayerMask Layer;

	// Use this for initialization
	void Start () {
        lazer = GetComponent<SpriteRenderer>();
        SetSize();
	}
	
	// Update is called once per frame
	void Update () {
        SetSize();
    }

    private void SetSize()
    {
        float angleDir = Mathf.Deg2Rad * transform.eulerAngles.z + (Mathf.PI / 2);
        Vector2 dir = new Vector2(Mathf.Cos(angleDir), Mathf.Sin(angleDir));
        var hit = Physics2D.Raycast(transform.position, dir, 1440.0f, Layer);
        if (hit)
        {
            if (Vector2.Distance(hit.point, transform.position) > 2.0f && gameObject != hit.transform.gameObject)
            {
                lazer.size = new Vector2(32.0f, Vector2.Distance(hit.point, transform.position));
            }
        }
        else
        {
            lazer.size = new Vector2(32.0f, 1440.0f);
        }
    }

}
