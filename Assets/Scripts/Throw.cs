using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour {

    [SerializeField]
    GameObject captureObject = null;

    GameObject Instance;

    Vector2 releasePosition;
    Vector2 grabPosition;

    [SerializeField]
    GameObject Root;

    [SerializeField]
    float sensitivity = 0.05f;

    Vector2 mousePosition { get { return Camera.main.ScreenToWorldPoint(Input.mousePosition); } }

    int state = 0;

    [SerializeField]
    AudioSource ReleaseSound;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (state == 0)
        {
            Instance = Instantiate(captureObject, transform.position, Quaternion.identity);
            Instance.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            Instance.GetComponent<Rigidbody2D>().simulated = false;

            state++;
        }else if ( state == 1 ) { 
            if (Input.GetMouseButtonDown(0))
            {
                grabPosition = mousePosition;
                state++;
            }
        }
        else if (state == 2)
        {
            //Debug.Log(mousePosition);
            //Debug.Log(prevPosition);
            //            Debug.Log(velocity);
            //Debug.Log( Instance.GetComponent<Rigidbody2D>().velocity );

            if (Input.GetMouseButtonUp(0))
            {
                releasePosition = new Vector2(mousePosition.x, mousePosition.y);
                Instance.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                Instance.GetComponent<Rigidbody2D>().simulated = true;

                Instance.GetComponent<Rigidbody2D>().velocity = (((releasePosition - grabPosition)) * sensitivity) * -1.0f;

                if (ReleaseSound != null) ReleaseSound.PlayOneShot(ReleaseSound.clip);
                //if ( releasePosition - grabPosition )

                Instance.transform.SetParent( Root.transform );
                state++;
            }
        }
    }

    private void FixedUpdate()
    {
        if ( state == 3)
        {
            if ( Instance == null || Instance.GetComponent<CheckStop>().isStop )state = 0;
        } 
    }

}
