using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {

    int EndScore;
    [SerializeField]
    Text stackText;

    string TWEET_TEXT
    {
        get { return "あなたは" + EndScore + "箱積み上げました。"; }
    }

    // Use this for initialization
    void Start () {
        if ( GameManager.Instance != null && GameManager.Instance.score != null )EndScore = GameManager.Instance.score.Value;
        if (stackText != null) stackText.text = "";
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

    private void OnGUI()
    {
        if (stackText != null && GameManager.Instance != null) stackText.text = GameManager.Instance.score.Value.ToString();
    }
}
