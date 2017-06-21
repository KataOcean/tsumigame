using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Tweet()
    {
        if (GameManager.Instance != null)
        {
            //本文＋ハッシュタグ＊２ツイート
            naichilab.UnityRoomTweet.Tweet("[YOUR-GAMEID-HERE]", "あなたは" + GameManager.Instance.score.Value + "箱積み上げました。", "unityroom", "unity1week");
        }
    }
       

    public void Retry()
    {
        SceneLoader.Replace( "main" );
    }
}
