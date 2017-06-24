using GSSA;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour {

    enum State
    {
        Title,
        Ready,
        Main,
        SendScore,
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
    public int FinishScore { get; private set; }

    [SerializeField]
    CheckCanEndGame checkCanEndGame;

    [SerializeField]
    MonoBehaviour throwScript;
    [SerializeField]
    MonoBehaviour vectorScript;

    bool isstart = false;

    State state = State.Title;

    bool skipframe = false;

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
        if (vectorScript != null) vectorScript.enabled = false;
    }

    // Use this for initialization
    void Start () {
        SceneLoader.Add( "Title" );
        SceneLoader.SetActive( gameObject.scene.name );
        skipframe = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (!skipframe)
        {
            switch (state)
            {
                case State.Title:
                    if (vectorScript != null) vectorScript.enabled = true;
                    if (Input.GetMouseButtonDown(0))
                    {
                        SceneLoader.Remove("Title");
                        SceneLoader.Add("Timer");
                        skipframe = true;
                        state = State.Ready;
                    }
                    break;
                case State.Ready:
                    if (Input.GetMouseButtonUp(0))
                    {
                        timer.StartTimer();
                        if (!BGM.isPlaying) BGM.Play();
                        state = State.Main;
                    }
                    break;
                case State.Main:
                    if (timer.IsEnd && checkCanEndGame.canEnd)
                    {
                        BGM.Stop();
                        score = countScore.Count(score);
                        FinishScore = score.Value;
                        SceneLoader.Remove("Timer");

                        //StartCoroutine(SendScore(score.Value));
                        SceneLoader.Add("Result");
                        skipframe = true;
                        state = State.Result;

                    }
                    break;
                case State.SendScore:
                    break;
                case State.Result:
                    if (throwScript != null) throwScript.enabled = true;
                    if (vectorScript != null) vectorScript.enabled = true;
                    score = countScore.Count(score);
                    break;
                default:
                    break;
            }
            
        }

        skipframe = false;

    }

}
