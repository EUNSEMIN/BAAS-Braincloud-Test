using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class LeaderboardsManager : MonoBehaviour
{
    public static LeaderboardsManager instance;

    private List<Leaderboard> leaderboards;
    private float userTime;

    private void Awake()
    {
        instance = this;
        leaderboards = new List<Leaderboard>();
    }

    public void AddLeaderboard(Leaderboard leaderboard)
    {
        if (userTime > 0.0f)
        {
            for (int i = 0; i < leaderboard.GetCount(); i++)
            {
                if (leaderboard.GetLeaderboardEntryAtIndex(i).Time == userTime)
                {
                    leaderboard.GetLeaderboardEntryAtIndex(i).IsUserScore = true;
                    break;
                }
            }
        }

        leaderboards.RemoveAll(p => p.Name == leaderboard.Name);

        leaderboards.Add(leaderboard);
    }

    public Leaderboard GetLeaderboardByName(string name)
    {
        for (int i = 0; i < leaderboards.Count; i++)
        {
            if (leaderboards[i].Name == name)
                return leaderboards[i];
        }
        return null;
    }

    public int GetCount()
    {
        return leaderboards.Count;
    }

    public void SetUserTime(float userTime)
    {
        long ms = (long)(userTime * 1000.0f);       // Convert the time from seconds to milleseconds
        userTime = (float)(ms) / 1000.0f;
    }
}
