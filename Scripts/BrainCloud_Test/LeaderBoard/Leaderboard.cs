using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Leaderboard
{
    //리더보드 이름
    private string name;

    //리더보드
    private List<LeaderboardEntry> leaderboard;

    //Get 리더보드 이름
    public string Name
    {
        get { return name; }
    }

    public Leaderboard(string _name, List<LeaderboardEntry> _leaderboard)
    {
        name = _name;
        leaderboard = _leaderboard;
    }

    //Index로 leaderboard entry 가져오기
    public LeaderboardEntry GetLeaderboardEntryAtIndex(int index)
    {
        if (index >= 0 && index < GetCount())
            return leaderboard[index];
        return null;
    }

    //enrtry 카운트?
    public int GetCount()
    {
        return leaderboard.Count;
    }
}