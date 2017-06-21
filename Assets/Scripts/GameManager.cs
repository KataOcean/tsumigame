using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    enum State
    {
        Title,
        Main,
        Result
    }

    public static GameManager Instance;
    [SerializeField]
    CountScore countScore;

    [SerializeField]
    AudioSource BGM;

    GameOver gameOver;

    public Timer timer { get; private set; }
    public Score score { get; private set; }

    [SerializeField]
    CheckCanEndGame checkCanEndGame;

    bool isstart = false;

    State state = State.Title;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Initialize();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Initialize()
    {
        timer = GetComponent<Timer>();
        score = new Score() { Value = 0 };
    }

    // Use this for initialization
    void Start () {
        SceneLoader.Add( "Title" );
        SceneLoader.SetActive( gameObject.scene.name );
	}
	
	// Update is called once per frame
	void Update () {

        switch (state)
        {
            case State.Title:
                if (Input.GetMouseButtonUp(0))
                {
                    timer.StartTimer();
                    if (!BGM.isPlaying) BGM.Play();
                    state = State.Main;
                }
                else
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        SceneLoader.Remove("Title");
                        SceneLoader.Add("Timer");
                    }
                }
                break;
            case State.Main:
                if (timer.IsEnd && checkCanEndGame.canEnd)
                {
                    BGM.Stop();
                    score = countScore.Count(score);
                    SceneLoader.Remove("Timer");
                    SceneLoader.Add("Result");

                }
                break;
            case State.Result:
                break;
            default:
                break;
        }

        
    }
}
