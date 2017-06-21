using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour {


    string TWEET_TEXT
    {
        get { return "あなたは" + GameManager.Instance.score.Value + "箱積み上げました。"; }
    }

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
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                //本文＋ハッシュタグ＊２ツイート
                naichilab.UnityRoomTweet.Tweet("[YOUR-GAMEID-HERE]", TWEET_TEXT, "積むゲーム" , "unityroom", "unity1week");
            }else
            {
                Application.OpenURL("http://twitter.com/intent/tweet?text=" + WWW.EscapeURL(TWEET_TEXT + " #積むゲーム"));
            }
        }
    }
       

    public void Retry()
    {
        SceneLoader.Replace( "main" );
    }
}
