using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

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
        SceneLoader.Add( "Timer" );
	}
	
	// Update is called once per frame
	void Update () {
        if (timer.IsEnd && checkCanEndGame.canEnd)
        {
            BGM.Stop();
            score = countScore.Count(score);
            SceneLoader.Remove("Timer");
            SceneLoader.Add("Result");

        }
        if (Input.GetMouseButtonUp(0))
        {
            timer.StartTimer();
            if (!BGM.isPlaying) BGM.PlayDelayed(1.0f);
        }
    }
}
