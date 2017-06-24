using GSSA;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ranking : MonoBehaviour {

    bool endSend = false;
    bool endReceive = false;

    Dictionary<int, int> scores = new Dictionary<int, int>();

	// Use this for initialization
	void Start () {
        if (GameManager.Instance != null) {
            var query = new SpreadSheetQuery();
            StartCoroutine(SendScore( GameManager.Instance.FinishScore,query ));
        }
	}

	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SendScore(int score,SpreadSheetQuery query)
    {
        yield return query.Where("score", "=", score).FindAsync();
        var sc = query.Result.FirstOrDefault();
        if (sc != null)
        {
            sc["number"] = (int)(sc["number"]) + 1;
        }
        else
        {
            sc = new SpreadSheetObject();
            sc["score"] = score;
            sc["number"] = 1;
        }

        yield return sc.SaveAsync();

        endSend = true;

        yield return GetRanking(query);

    }

    IEnumerator GetRanking(SpreadSheetQuery query)
    {
        scores = new Dictionary<int, int>();
        yield return query.Where("number", ">", 0).Limit(20).FindAsync();
        foreach ( var sc in query.Result)
        {
            scores.Add((int)sc["score"], (int)sc["number"]);
        }
        endReceive = true;

        yield return null;
    }
}
