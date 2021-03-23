using Kuhpik;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ShowResultSystem : GameSystem, IIniting
{
    [SerializeField] TextMeshProUGUI result;
    [SerializeField] TextMeshProUGUI record;
    [SerializeField] TextMeshProUGUI leaderboardPlayers;
    [SerializeField] TextMeshProUGUI leaderboardScore;

    void IIniting.OnInit()
    {
        result.text = "Result: " + game.latestResult;
        record.text = "Record: " + player.record;

        var jsonTextFile = Resources.Load<TextAsset>("leaderboard");
        string content = jsonTextFile.ToString();
        ScoreList newList = JsonUtility.FromJson<ScoreList>("{\"players\":" + content + "}");

        foreach (var player in newList.players)
        {
            leaderboardPlayers.text += player.name + "\n";
        }

        foreach (var score in newList.players)
        {
            leaderboardScore.text += score.score + "\n";
        }
    }
}
