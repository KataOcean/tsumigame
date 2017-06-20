using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour {

    [SerializeField]
    GameObject captureObject = null;

    GameObject Instance;

    Vector2 prevPosition , releasePosition , velocity;
    Vector2 grabPosition;

    [SerializeField]
    float sensitivity = 0.1f;

    Vector2 mousePosition { get { return Camera.main.ScreenToWorldPoint(Input.mousePosition); } }

    int state = 0;

	// Use this for initialization
	void Start () {
        velocity = new Vector2();
	}
	
	// Update is called once per frame
	void Update () {
        if (state == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instance = Instantiate(captureObject, transform.position, Quaternion.identity);
                Instance.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

                grabPosition = mousePosition;
                state++;
            }
        }
        else if (state == 1)
        {
            //Debug.Log(mousePosition);
            //Debug.Log(prevPosition);
            //            Debug.Log(velocity);
            //Debug.Log( Instance.GetComponent<Rigidbody2D>().velocity );

            if (Input.GetMouseButtonUp(0))
            {
                releasePosition = new Vector2(mousePosition.x, mousePosition.y);
                Instance.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                Instance.GetComponent<Rigidbody2D>().velocity = (((releasePosition - grabPosition)) * sensitivity) * -1.0f;
                //velocity = ((releasePosition - prevPosition) / Time.deltaTime) * sensitivity;
                state++;
            }
            else
            {
            }
        }
        prevPosition = new Vector2(mousePosition.x, mousePosition.y);
    }

    private void FixedUpdate()
    {
        if ( state == 2)
        {
            state = 0;
            //var obj = Instantiate(captureObject, transform.position, Quaternion.identity);
            //var body = obj.GetComponent<Rigidbody2D>();
            //body.velocity = new Vector2( velocity.x , velocity.y );
        } 
       
        // if ( captureObject != null)
        // {
        //var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //captureObject.GetComponent<Rigidbody2D>().MovePosition(pos);
        // }
    }

}
