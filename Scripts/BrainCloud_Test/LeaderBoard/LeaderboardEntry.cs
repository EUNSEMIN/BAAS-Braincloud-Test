using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class LeaderboardEntry
{
    private string nickname;

    private float time;

    private int rank;

    private bool isUserScore;

    public LeaderboardEntry(string _nickname, int _rank, float _time)
    {
        nickname = _nickname;
        rank = _rank;
        time= _time;
    }

    public string Nickname
    {
        get { return nickname; }
        set { nickname = value; }
    }

    public float Time
    {
        get { return time; }
        set { time = value; }
    }

    public int Rank
    {
        get { return rank ; }
        set { rank = value; }
    }

    public bool IsUserScore
    {
        get { return isUserScore; }
        set { isUserScore = value; }
    }
}
