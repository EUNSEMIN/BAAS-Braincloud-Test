using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Leaderboard
{
    //�������� �̸�
    private string name;

    //��������
    private List<LeaderboardEntry> leaderboard;

    //Get �������� �̸�
    public string Name
    {
        get { return name; }
    }

    public Leaderboard(string _name, List<LeaderboardEntry> _leaderboard)
    {
        name = _name;
        leaderboard = _leaderboard;
    }

    //Index�� leaderboard entry ��������
    public LeaderboardEntry GetLeaderboardEntryAtIndex(int index)
    {
        if (index >= 0 && index < GetCount())
            return leaderboard[index];
        return null;
    }

    //enrtry ī��Ʈ?
    public int GetCount()
    {
        return leaderboard.Count;
    }
}