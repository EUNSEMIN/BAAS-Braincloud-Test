using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Data : MonoBehaviour
{
    public UserData userData = new UserData();

    public string entityId = "";
    public string UserEntity_FailNum = "0";

    /// <summary>
    /// UserEntity
    /// </summary>
    public void SetUserEntityWinNumJson()
    {
        UserEntity_FailNum = $"{{\"NickName\": \"{userData.nickName}\",\"Level\": \"{userData.level}\", \"Score\": \"{userData.score}\"}}";
    }


    /// <summary>
    /// Division Leaderboard
    /// </summary>
    public void UpdateUserDivision()
    {
        Network.instance.JoinDivision(userData.division_st, "Division1_To",0);
    }

    public void GetUserDivision()
    {
        Network.instance.GetMyDivision();
    }

    public void LeaveDivision()
    {
        Network.instance.LeaveDivison(userData.division);
    }

    public void PostScoreTournament()
    {
        Network.instance.PostScoreTournamentUTC(userData.division_st, userData.score, $"{{\"NickName\":\"{userData.nickName}\"}}");
    }
}
