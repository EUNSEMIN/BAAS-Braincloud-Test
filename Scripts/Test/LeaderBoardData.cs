using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderBoardData : MonoBehaviour
{
    #region Variables

    private Data data;

    [SerializeField]
    private List<TMP_Text> leaderBoardDivision;

    [SerializeField]
    private List<TMP_Text> leaderBoardScore;

    [SerializeField]
    private List<TMP_Text> leaderBoardPlayerId;

    [SerializeField]
    private TMP_Text division;

    [SerializeField]
    private TMP_Text userName;

    #endregion

    private void OnEnable()
    {
        data = DataManager.Instance.data;
    }

    public void UpdateLeaderBoard()
    {
        this.division.text = data.userData.division;

        RequestLeaderboardData();
    }

    public void RequestLeaderboardData()
    {
        Network.instance.RequestLeaderboard("^D^Division1^3", 0, 3, OnRequestLeaderBoard);
    }

    private void OnRequestLeaderBoard(ref List<string> playerId, ref List<string> score)
    {
        //Update score
        Debug.Log(score.Count);
        Debug.Log(leaderBoardScore.Count);

        for (int i = 0; i < score.Count && i < leaderBoardScore.Count; i++)
        {
            Debug.Log("Hi");
            leaderBoardScore[i].text = score[i];
        }

        //Update playerId
        for (int i = 0; i < playerId.Count && i < leaderBoardPlayerId.Count; i++)
        {
            leaderBoardPlayerId[i].text = playerId[i];
        }
    }

    #region Individual User Info

    public void CheckClickUser(int id)
    {
        //Order by ranking
        switch (id)
        {
            case 0:
                Network.instance.GetOtherUserEntity(leaderBoardPlayerId[0].text, OnGetOtherUserEntity);
                break;
            case 1:
                Network.instance.GetOtherUserEntity(leaderBoardPlayerId[1].text, OnGetOtherUserEntity);
                break;
            case 2:
                Network.instance.GetOtherUserEntity(leaderBoardPlayerId[2].text, OnGetOtherUserEntity);
                break;
        }
    }

    private void OnGetOtherUserEntity(ref string name)
    {
        this.userName.text = name;
    }

    #endregion
}
