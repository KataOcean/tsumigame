using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowClickVector : MonoBehaviour {

    [SerializeField]
    Image vector;

    Vector2 grabPosition;
    Vector2 dragPosition;

    bool isDrag = false;

	// Use this for initialization
	void Start () {
		vector.color = Color.white *0.0f;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0)){
            grabPosition = Input.mousePosition;
            isDrag = true;
        }
        if ( Input.GetMouseButtonUp(0) )
        {
            isDrag = false;
        }
    }

    private void OnGUI()
    {
        
        if ( vector != null )
        {
            vector.color = Color.white * ((isDrag) ? 1.0f : 0.0f);
            if (isDrag)
            {
                dragPosition = Input.mousePosition;
                vector.rectTransform.position = dragPosition;
                vector.rectTransform.sizeDelta = new Vector2(Vector2.Distance(grabPosition, dragPosition), 900.0f);
                vector.rectTransform.rotation = Quaternion.FromToRotation(Vector2.right, grabPosition - dragPosition);
            }
        }
    }

    // p2からp1への角度を求める
    // @param p1 自分の座標
    // @param p2 相手の座標
    // @return 2点の角度(Degree)
    public float GetAim(Vector2 p1, Vector2 p2)
    {
        float dx = p2.x - p1.x;
        float dy = p2.y - p1.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }

    private void OnDisable()
    {
        isDrag = false;
    }
}
