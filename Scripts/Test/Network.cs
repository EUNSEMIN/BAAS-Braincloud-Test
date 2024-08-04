//System
using System;
using System.Collections;
using System.Collections.Generic;

//Unity
using UnityEngine;
using UnityEngine.Networking;

//BrainCloud
using BrainCloud.LitJson;
using UnityEngine.SocialPlatforms.Impl;
using static Network;

public class Network : MonoBehaviour
{
    public static Network instance;

    private BrainCloudWrapper brainCloud;

    //About Authenticaion
    public delegate void AuthenticationRequestCompleted();
    public delegate void AuthenticationRequestFailed();

    public delegate void BrainCloudLogOutCompleted();
    public delegate void BrainCloudLogOutFailed();

    public delegate void AppleLoginCompleted();
    public delegate void AppleLoginFailed();

    public delegate void GoogleLoginCompleted();
    public delegate void GoogleLoginFailed();

    //UserName
    public delegate void UpdateUsernameRequestCompleted();
    public delegate void UpdateUsernameRequestFailed();

    //About LeaderBoard
    public delegate void LeaderboardRequestCompleted(ref List<string> list1, ref List<string> list2);
    public delegate void LeaderboardRequestFailed();

    public delegate void PostScoreRequestCompleted();
    public delegate void PostScoreRequestFailed();

    //Division
    public delegate void GetMyDivisionCompleted();
    public delegate void GetMyDivisionFailed();

    public delegate void JoinDivisionCompleted();
    public delegate void JoinDivisionFailed();

    public delegate void LeaveDivionInstanceCompleted();
    public delegate void LeaveDivionInstanceFailed();

    public delegate void PostScoreTournamentUTCCompleted();
    public delegate void PostScoreTournamentUTCFailed();

    //Global Entity
    public delegate void RequestGlobalEntityLevelDataCompleted(ref JsonData data);
    public delegate void RequestGlobalEntityLevelDataFailed();

    //User Statistic
    public delegate void UserStatisticsRequestCompleted(ref List<Statistic> statistics);
    public delegate void UserStatisticsRequestFailed();

    public delegate void IncrementUserStatisticsCompleted(ref List<Statistic> statistics);
    public delegate void IncrementUserStatisticsFailed();

    public delegate void ReadUserStatisticsCompleted();
    public delegate void ReadUserStatisticsFailed();

    public delegate void GetUserStatisticsCompleted();
    public delegate void GetUserStatisticsFailed();

    //UserEntity
    public delegate void RequestUserEntityDataCompleted(ref List<string> entityIds);
    public delegate void RequestUserEntityDataFailed();

    public delegate void CreateUserEntityDataCompleted();
    public delegate void CreateUserEntityDataFailed();

    public delegate void UpdateUserEntityDataCompleted();
    public delegate void UpdateUserEntityDataFailed();

    public delegate void GetOtherUserEntityCompleted(ref string name);
    public delegate void GetOtherUserEntityFailed();


    [SerializeField]
    private string userName;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);

        // Create and initialize BrainCloud wrapper
        brainCloud = gameObject.AddComponent<BrainCloudWrapper>();
        brainCloud.Init();

        //BrainCloud client version
        Debug.Log("BrainCloud client version: " + brainCloud.Client.BrainCloudClientVersion);

        Debug.Log(brainCloud.GetStoredProfileId());
        Debug.Log(brainCloud.GetStoredAnonymousId());

    }

    private void Update()
    {
        //콜백 메소드
        brainCloud.RunCallbacks();
    }

    public bool IsAuthenticated()
    {
        return brainCloud.Client.Authenticated;
    }

    public bool HasAuthenticatedPreviously()
    {
        return brainCloud.GetStoredProfileId() != "";
        //&& brainCloud.GetStoredAnonymousId() != ""
    }

    public string GetUserName()
    {
        return userName;
    }

    public bool IsUsernameSaved()
    {
        return userName != "";
    }

    /// <summary>
    /// Authenticaion
    /// </summary>
    public void RequestAnonymousAuthentication(AuthenticationRequestCompleted authenticationRequestCompleted = null, AuthenticationRequestFailed authenticationRequestFailed = null)
    {
        BrainCloud.SuccessCallback successCallback = (responseData, cbObject) =>
        {
            Debug.Log("Anonymous authentication success: " + responseData);
            HandleAuthenticationSuccess(responseData, cbObject, authenticationRequestCompleted);
        };

        BrainCloud.FailureCallback failureCallback = (statusMessage, code, error, cbObject) =>
        {
            Debug.Log("Anonymous authentication failed. " + statusMessage);

            if (authenticationRequestFailed != null)
                authenticationRequestFailed();
        };

        brainCloud.AuthenticateAnonymous(successCallback, failureCallback);
    }

    public void RequestAuthenticationUniversal(string userID, string password, AuthenticationRequestCompleted authenticationRequestCompleted = null, AuthenticationRequestFailed authenticationRequestFailed = null)
    {
        BrainCloud.SuccessCallback successCallback = (responseData, cbObject) =>
        {
            Debug.Log("RequestAuthenticationUniversal success: " + responseData);
            HandleAuthenticationSuccess(responseData, cbObject, authenticationRequestCompleted);
        };

        BrainCloud.FailureCallback failureCallback = (statusMessage, code, error, cbObject) =>
        {
            Debug.Log("Universial authentication failed. " + statusMessage);

            if (authenticationRequestFailed != null)
                authenticationRequestFailed();
        };

        brainCloud.AuthenticateUniversal(userID, password, true, successCallback, failureCallback);
    }

    public void RequestGoogleAuthenticaion(string googleUserId, string serverAuthCode, bool forceCreate, GoogleLoginCompleted googleLoginCompleted = null, GoogleLoginFailed googleLoginFailed = null)
    {
        BrainCloud.SuccessCallback successCallback = (responseData, cbObject) =>
        {
            Debug.Log("RequestAuthenticationUniversal success: " + responseData);

            if (googleLoginCompleted != null)
                googleLoginCompleted();
        };

        BrainCloud.FailureCallback failureCallback = (statusMessage, code, error, cbObject) =>
        {
            Debug.Log("Universial authentication failed. " + statusMessage);

            if (googleLoginFailed != null)
                googleLoginFailed();
        };

        brainCloud.AuthenticateGoogle(googleUserId, serverAuthCode , forceCreate, successCallback, failureCallback);
    }

    public void RequestAppleAuthenticaion(string appleUserId, string identityToken, bool forceCreate, AppleLoginCompleted appleLoginCompleted = null, AppleLoginFailed appleLoginFailed = null)
    {
        BrainCloud.SuccessCallback successCallback = (responseData, cbObject) =>
        {
            Debug.Log("RequestAuthenticationUniversal success: " + responseData);

            if (appleLoginCompleted != null)
                appleLoginCompleted();
        };

        BrainCloud.FailureCallback failureCallback = (statusMessage, code, error, cbObject) =>
        {
            Debug.Log("Universial authentication failed. " + statusMessage);

            if (appleLoginFailed != null)
                appleLoginFailed();
        };

        brainCloud.AuthenticateApple(appleUserId, identityToken, forceCreate, successCallback, failureCallback);
    }


    public void Reconnect(AuthenticationRequestCompleted authenticationRequestCompleted = null, AuthenticationRequestFailed authenticationRequestFailed = null)
    {
        BrainCloud.SuccessCallback successCallback = (responseData, cbObject) =>
        {
            Debug.Log("Reconnect success: " + responseData);
            HandleAuthenticationSuccess(responseData, cbObject, authenticationRequestCompleted);
        };

        BrainCloud.FailureCallback failureCallback = (statusMessage, code, error, cbObject) =>
        {
            Debug.Log("Reconnect authentication failed. " + statusMessage);

            if (authenticationRequestFailed != null)
                authenticationRequestFailed();
        };

        brainCloud.Reconnect(successCallback, failureCallback);
    }

    public void LogOut(BrainCloudLogOutCompleted brainCloudLogOutCompleted = null, BrainCloudLogOutFailed brainCloudLogOutFailed = null)
    {
        if (IsAuthenticated())
        {
            BrainCloud.SuccessCallback successCallback = (responseData, cbObject) =>
            {
                Debug.Log("LogOut success: " + responseData);

                if (brainCloudLogOutCompleted != null)
                    brainCloudLogOutCompleted();
            };

            BrainCloud.FailureCallback failureCallback = (statusMessage, code, error, cbObject) =>
            {
                Debug.Log("BrainCloud Logout failed: " + statusMessage);

                if (brainCloudLogOutFailed != null)
                    brainCloudLogOutFailed();
            };

            // true하면 장치에 저장된 프로필 id가 삭제되는 반면, false일 때에는 세션은 종료되지만 저장된 프로필 id는 삭제되지 않음
            //?? 확인 필요
            brainCloud.Logout(true, successCallback, failureCallback);
        }
        else
        {
            Debug.Log("BrainCloud Logout failed: user is not authenticated");

            if (brainCloudLogOutFailed != null)
                brainCloudLogOutFailed();
        }
    }

    /// <summary>
    /// UserName
    /// </summary>
    public void RequestUpdateUsername(string username, UpdateUsernameRequestCompleted updateUsernameRequestCompleted = null, UpdateUsernameRequestFailed updateUsernameRequestFailed = null)
    {
        if (IsAuthenticated())
        {
            // Success callback lambda
            BrainCloud.SuccessCallback successCallback = (responseData, cbObject) =>
            {
                Debug.Log("RequestUpdateUsername success: " + responseData);

                JsonData jsonData = JsonMapper.ToObject(responseData);
                userName = jsonData["data"]["playerName"].ToString();

                if (updateUsernameRequestCompleted != null)
                    updateUsernameRequestCompleted();
            };

            // Failure callback lambda
            BrainCloud.FailureCallback failureCallback = (statusMessage, code, error, cbObject) =>
            {
                Debug.Log("RequestUpdateUsername failed: " + statusMessage);

                if (updateUsernameRequestFailed != null)
                    updateUsernameRequestFailed();
            };

            // Make the BrainCloud request
            brainCloud.PlayerStateService.UpdateName(username, successCallback, failureCallback);
        }
        else
        {
            Debug.Log("RequestUpdateUsername failed: user is not authenticated");

            if (updateUsernameRequestFailed != null)
                updateUsernameRequestFailed();
        }
    }

    /// <summary>
    /// LeaderBoard
    /// </summary>
    public void RequestLeaderboard(string leaderboardId, int startIndex, int endIndex, LeaderboardRequestCompleted leaderboardRequestCompleted = null, LeaderboardRequestFailed leaderboardRequestFailed = null)
    {
        if (IsAuthenticated())
        {
            BrainCloud.SuccessCallback successCallback = (responseData, cbObject) =>
            {
                Debug.Log("RequestLeaderboard success: " + responseData);

                // Read the json and update our values
                JsonData jsonData = JsonMapper.ToObject(responseData);
                JsonData leaderboard = jsonData["data"]["leaderboard"];

                Debug.Log(leaderboard);

                List<string> leaderboardPlayerId = new List<string>();
                List<string> leaderboardScore = new List<string>();

                if (leaderboard.IsArray)
                {
                    for (int i = 0; i < leaderboard.Count; i++)
                    {
                        leaderboardPlayerId.Add(leaderboard[i]["playerId"].ToString());
                        leaderboardScore.Add(leaderboard[i]["score"].ToString());
                    }
                }

                if (leaderboardRequestCompleted != null)
                    leaderboardRequestCompleted(ref leaderboardPlayerId, ref leaderboardScore);
            };

            BrainCloud.FailureCallback failureCallback = (statusMessage, code, error, cbObject) =>
            {
                Debug.Log("RequestLeaderboard failed: " + statusMessage);

                if (leaderboardRequestFailed != null)
                    leaderboardRequestFailed();
            };

            brainCloud.LeaderboardService.GetGlobalLeaderboardPage(leaderboardId, BrainCloud.BrainCloudSocialLeaderboard.SortOrder.HIGH_TO_LOW, startIndex, endIndex, successCallback, failureCallback);
        }
        else
        {
            Debug.Log("RequestLeaderboard failed: user is not authenticated");

            if (leaderboardRequestFailed != null)
                leaderboardRequestFailed();
        }
    }

    public void PostScoreToLeaderboard(string leaderboardID, float time, string nickname, PostScoreRequestCompleted postScoreRequestCompleted = null, PostScoreRequestFailed postScoreRequestFailed = null)
    {
        if (IsAuthenticated())
        {
            BrainCloud.SuccessCallback successCallback = (responseData, cbObject) =>
            {
                Debug.Log("PostScoreToLeaderboard success: " + responseData);

                if (postScoreRequestCompleted != null)
                    postScoreRequestCompleted();
            };

            BrainCloud.FailureCallback failureCallback = (statusMessage, code, error, cbObject) =>
            {
                Debug.Log("PostScoreToLeaderboard failed: " + statusMessage);

                if (postScoreRequestFailed != null)
                    postScoreRequestFailed();
            };

            // Make the BrainCloud request
            long score = (long)(time * 1000.0f);   // Convert the time from seconds to milleseconds
            string jsonOtherData = "{\"nickname\":\"" + nickname + "\"}";
            brainCloud.LeaderboardService.PostScoreToLeaderboard(leaderboardID, score, jsonOtherData, successCallback, failureCallback);
        }
        else
        {
            Debug.Log("PostScoreToLeaderboard failed: user is not authenticated");

            if (postScoreRequestFailed != null)
                postScoreRequestFailed();
        }
    }

    /// <summary>
    /// Global Entity
    /// </summary>
    public void RequestGlobalEntityLevelData(RequestGlobalEntityLevelDataCompleted requestGlobalEntityLevelDataCompleted = null, RequestGlobalEntityLevelDataFailed requestGlobalEntityLevelDataFailed = null)
    {
        if (IsAuthenticated())
        {
            BrainCloud.SuccessCallback successCallback = (responseData, cbObject) =>
            {
                Debug.Log("RequestGlobalEntityLevelData success: " + responseData);

                JsonData jsonData = JsonMapper.ToObject(responseData);
                JsonData entityData = jsonData["data"];

                if (requestGlobalEntityLevelDataCompleted != null)
                    requestGlobalEntityLevelDataCompleted(ref entityData);
            };

            BrainCloud.FailureCallback failureCallback = (statusMessage, code, error, cbObject) =>
            {
                Debug.Log("RequestUserEntityData failed: " + statusMessage);

                if (requestGlobalEntityLevelDataFailed != null)
                    requestGlobalEntityLevelDataFailed();
            };

            brainCloud.GlobalEntityService.GetListByIndexedId(Constants.brainCloudGlobalEntityIndexedID, 5, successCallback, failureCallback);
        }
        else
        {
            Debug.Log("RequestUserEntityData failed: user is not authenticated");

            if (requestGlobalEntityLevelDataFailed != null)
                requestGlobalEntityLevelDataFailed();
        }
    }

    /// <summary>
    /// User Statistic
    /// </summary>
    public void RequestUserStatistics(UserStatisticsRequestCompleted userStatisticsRequestCompleted = null, UserStatisticsRequestFailed userStatisticsRequestFailed = null)
    {
        if (IsAuthenticated())
        {
            BrainCloud.SuccessCallback successCallback = (responseData, cbObject) =>
            {
                Debug.Log("RequestUserStatistics success: " + responseData);

                JsonData jsonData = JsonMapper.ToObject(responseData);
                JsonData statistics = jsonData["data"]["statistics"];

                List<Statistic> statisticsList = ParseStatistics(ref statistics);

                if (userStatisticsRequestCompleted != null)
                    userStatisticsRequestCompleted(ref statisticsList);
            };

            BrainCloud.FailureCallback failureCallback = (statusMessage, code, error, cbObject) =>
            {
                Debug.Log("RequestUserStatistics failed: " + statusMessage);

                if (userStatisticsRequestFailed != null)
                    userStatisticsRequestFailed();
            };

            brainCloud.PlayerStatisticsService.ReadAllUserStats(successCallback, failureCallback);
        }
        else
        {
            Debug.Log("RequestUserStatistics failed: user is not authenticated");

            if (userStatisticsRequestFailed != null)
                userStatisticsRequestFailed();
        }
    }

    public void IncrementUserStatistics(Dictionary<string, object> data, IncrementUserStatisticsCompleted incrementUserStatisticsCompleted = null, IncrementUserStatisticsFailed incrementUserStatisticsFailed = null)
    {
        if (IsAuthenticated())
        {
            BrainCloud.SuccessCallback successCallback = (responseData, cbObject) =>
            {
                Debug.Log("IncrementUserStatistics success: " + responseData);

                JsonData jsonData = JsonMapper.ToObject(responseData);
                JsonData statistics = jsonData["data"]["statistics"];

                List<Statistic> statisticsList = new List<Statistic>();

                long value = 0;
                string description;

                foreach (string key in statistics.Keys)
                {
                    value = long.Parse(statistics[key].ToString());
                    description = Constants.brainCloudStatDescriptions[key];
                    statisticsList.Add(new Statistic(key, value));
                }

                if (incrementUserStatisticsCompleted != null)
                    incrementUserStatisticsCompleted(ref statisticsList);
            };

            BrainCloud.FailureCallback failureCallback = (statusMessage, code, error, cbObject) =>
            {
                Debug.Log("IncrementUserStatistics failed: " + statusMessage);

                if (incrementUserStatisticsFailed != null)
                    incrementUserStatisticsFailed();
            };

            brainCloud.PlayerStatisticsService.IncrementUserStats(data, successCallback, failureCallback);
        }
        else
        {
            Debug.Log("IncrementUserStatistics failed: user is not authenticated");

            if (incrementUserStatisticsFailed != null)
                incrementUserStatisticsFailed();
        }
    }

    /// <summary>
    /// User Entity
    /// </summary>
    public void RequestUserEntityData(string entityType, RequestUserEntityDataCompleted requestUserEntityDataCompleted = null, RequestUserEntityDataFailed requestUserEntityDataFailed = null)
    {
        if (IsAuthenticated())
        {
            BrainCloud.SuccessCallback successCallback = (responseData, cbObject) =>
            {
                Debug.Log("RequestUserEntityData success: " + responseData);

                JsonData jsonData = JsonMapper.ToObject(responseData);
                JsonData entities = jsonData["data"]["entities"];

                List<string> entityIds = new List<string>();

                foreach (JsonData entity in entities)
                {
                    string entityId = entity["data"]["Score"].ToString();
                    entityIds.Add(entityId);
                }

                if (requestUserEntityDataCompleted != null)
                    requestUserEntityDataCompleted(ref entityIds);
            };

            BrainCloud.FailureCallback failureCallback = (statusMessage, code, error, cbObject) =>
            {
                Debug.Log("RequestUserEntityData failed: " + statusMessage);

                if (requestUserEntityDataFailed != null)
                    requestUserEntityDataFailed();
            };

            brainCloud.EntityService.GetEntitiesByType(entityType, successCallback, failureCallback);
        }
        else
        {
            Debug.Log("RequestUserEntityData failed: user is not authenticated");

            if (requestUserEntityDataFailed != null)
                requestUserEntityDataFailed();
        }
    }

    public void CreateUserEntityData(CreateUserEntityDataCompleted createUserEntityDataCompleted = null, CreateUserEntityDataFailed createUserEntityDataFailed = null)
    {
        if (IsAuthenticated())
        {
            BrainCloud.SuccessCallback successCallback = (responseData, cbObject) =>
            {
                Debug.Log("CreateUserEntityData success: " + responseData);

                if (createUserEntityDataCompleted != null)
                    createUserEntityDataCompleted();
            };

            BrainCloud.FailureCallback failureCallback = (statusMessage, code, error, cbObject) =>
            {
                Debug.Log("CreateUserEntityData failed: " + statusMessage);

                if (createUserEntityDataFailed != null)
                    createUserEntityDataFailed();
            };

            brainCloud.EntityService.CreateEntity(Constants.kBrainCloudUserProgressUserEntityType,
                                                    Constants.kBrainCloudUserProgressUserEntityDefaultData,
                                                    Constants.kBrainCloudUserProgressUserEntityDefaultAcl,
                                                    successCallback, failureCallback);
        }
        else
        {
            Debug.Log("CreateUserEntityData failed: user is not authenticated");

            if (createUserEntityDataFailed != null)
                createUserEntityDataFailed();
        }
    }

    public void UpdateUserEntityData(string entityID, string entityType, string jsonData, UpdateUserEntityDataCompleted updateUserEntityDataCompleted = null, UpdateUserEntityDataFailed updateUserEntityDataFailed = null)
    {
        if (IsAuthenticated())
        {
            BrainCloud.SuccessCallback successCallback = (responseData, cbObject) =>
            {
                Debug.Log("UpdateUserEntityData success: " + responseData);

                if (updateUserEntityDataCompleted != null)
                    updateUserEntityDataCompleted();
            };

            BrainCloud.FailureCallback failureCallback = (statusMessage, code, error, cbObject) =>
            {
                Debug.Log("UpdateUserEntityData failed: " + statusMessage);

                if (updateUserEntityDataFailed != null)
                    updateUserEntityDataFailed();
            };

            brainCloud.EntityService.UpdateEntity(entityID, entityType, jsonData, Constants.kBrainCloudUserProgressUserEntityDefaultAcl, -1, successCallback, failureCallback);
        }
        else
        {
            Debug.Log("UpdateUserEntityData failed: user is not authenticated");

            if (updateUserEntityDataFailed != null)
                updateUserEntityDataFailed();
        }
    }

    public void GetOtherUserEntity(string pofileId, GetOtherUserEntityCompleted getOtherUserEntityCompleted = null, GetOtherUserEntityFailed getOtherUserEntityFailed = null)
    {
        string name = "";

        if (IsAuthenticated())
        {
            BrainCloud.SuccessCallback successCallback = (responseData, cbObject) =>
            {
                Debug.Log("GetOtherUserEntity success: " + responseData);

                JsonData jsonData = JsonMapper.ToObject(responseData);
                JsonData entities = jsonData["data"]["entities"];

                foreach (JsonData entity in entities)
                {
                    name = entity["data"]["Nickname"].ToString();
                }

                if (getOtherUserEntityCompleted != null)
                    getOtherUserEntityCompleted(ref name);
            };

            BrainCloud.FailureCallback failureCallback = (statusMessage, code, error, cbObject) =>
            {
                Debug.Log("GetOtherUserEntity failed: " + statusMessage);

                if (getOtherUserEntityFailed != null)
                    getOtherUserEntityFailed();
            };

            brainCloud.EntityService.GetSharedEntitiesForProfileId(pofileId, successCallback, failureCallback);
        }
        else
        {
            Debug.Log("GetOtherUserEntity failed");

            if (getOtherUserEntityFailed != null)
                getOtherUserEntityFailed();
        }
    }

    /// <summary>
    /// Division
    /// </summary>
    public void GetMyDivision(GetMyDivisionCompleted getMyDivisionCompleted = null, GetMyDivisionFailed getMyDivisionFailed = null)
    {
        if (IsAuthenticated())
        {
            BrainCloud.SuccessCallback successCallback = (responseData, cbObject) =>
            {
                Debug.Log("GetMyDivision success: " + responseData);

                JsonData jsonData = JsonMapper.ToObject(responseData);
                JsonData entities = jsonData["data"]["CLAIMABLE"];

                foreach (string k in entities.Keys)
                {
                    DataManager.Instance.data.userData.division = k;
                }
                DataManager.Instance.data.userData.division_st = $"^D^{DataManager.Instance.data.userData.division}^2";

                if (getMyDivisionCompleted != null)
                    getMyDivisionCompleted();
            };
            BrainCloud.FailureCallback failureCallback = (statusMessage, code, error, cbObject) =>
            {
                Debug.Log("GetMyDivision failed: " + statusMessage);

                if (getMyDivisionFailed != null)
                    getMyDivisionFailed();
            };

            brainCloud.TournamentService.GetMyDivisions(successCallback, failureCallback);
        }
        else
        {
            Debug.Log("UpdateUserEntityData failed: user is not authenticated");

            if (getMyDivisionFailed != null)
                getMyDivisionFailed();
        }
    }

    public void JoinDivision(string divisionId, string tournamentCode, int initialScore, JoinDivisionCompleted joinDivisionCompleted = null, JoinDivisionFailed joinDivisionFailed = null)
    {
        if (IsAuthenticated())
        {
            BrainCloud.SuccessCallback successCallback = (responseData, cbObject) =>
            {
                Debug.Log("JoinDivision success: " + responseData);

                if (joinDivisionCompleted != null)
                    joinDivisionCompleted();
            };

            BrainCloud.FailureCallback failureCallback = (statusMessage, code, error, cbObject) =>
            {
                Debug.Log("JoinDivision failed: " + statusMessage);

                if (joinDivisionFailed != null)
                    joinDivisionFailed();
            };

            brainCloud.TournamentService.JoinDivision(divisionId, tournamentCode, initialScore, successCallback, failureCallback);
        }
        else
        {
            Debug.Log("UpdateUserEntityData failed: user is not authenticated");

            if (joinDivisionFailed != null)
                joinDivisionFailed();
        }
    }

    public void LeaveDivison(string divisionId, LeaveDivionInstanceCompleted leaveDivionInstanceCompleted = null, LeaveDivionInstanceFailed leaveDivionInstanceFailed= null)
    {
        if (IsAuthenticated())
        {
            BrainCloud.SuccessCallback successCallback = (responseData, cbObject) =>
            {
                Debug.Log("LeaveDivison success: " + responseData);

                if (leaveDivionInstanceCompleted != null)
                    leaveDivionInstanceCompleted();
            };

            BrainCloud.FailureCallback failureCallback = (statusMessage, code, error, cbObject) =>
            {
                Debug.Log("LeaveDivison failed: " + statusMessage);

                if (leaveDivionInstanceFailed != null)
                    leaveDivionInstanceFailed();
            };

            brainCloud.TournamentService.LeaveDivisionInstance(divisionId, successCallback, failureCallback);
        }
        else
        {
            Debug.Log("UpdateUserEntityData failed: user is not authenticated");

            if (leaveDivionInstanceFailed != null)
                leaveDivionInstanceFailed();
        }
    }

    public void PostScoreTournamentUTC(string leaderboardId, int score, string jsonData, PostScoreTournamentUTCCompleted postScoreTournamentUTCCompleted = null, PostScoreTournamentUTCFailed postScoreTournamentUTCFailed = null)
    {
        if (IsAuthenticated())
        {
            BrainCloud.SuccessCallback successCallback = (responseData, cbObject) =>
            {
                Debug.Log("PostScoreTournamentUTC success: " + responseData);

                if (postScoreTournamentUTCCompleted != null)
                    postScoreTournamentUTCCompleted();
            };

            BrainCloud.FailureCallback failureCallback = (statusMessage, code, error, cbObject) =>
            {
                Debug.Log("PostScoreTournamentUTC failed: " + statusMessage);

                if (postScoreTournamentUTCFailed != null)
                    postScoreTournamentUTCFailed();
            };

            // Convert DateTime to Unix timestamp
            DateTime currentTime = DateTime.UtcNow;
            ulong unixTimestamp = (ulong)((DateTimeOffset)currentTime).ToUnixTimeMilliseconds();

            brainCloud.TournamentService.PostTournamentScoreUTC(leaderboardId, score, jsonData, unixTimestamp, successCallback, failureCallback);
        }
        else
        {
            Debug.Log("UpdateUserEntityData failed: user is not authenticated");

            if (postScoreTournamentUTCFailed != null)
                postScoreTournamentUTCFailed();
        }
    }

    /// <summary>
    /// Ect
    private List<Statistic> ParseStatistics(ref JsonData statisticsData)
    {
        List<Statistic> statisticsList = new List<Statistic>();
        long value = 0;

        foreach (string key in statisticsData.Keys)
        {
            value = long.Parse(statisticsData[key].ToString());
            statisticsList.Add(new Statistic(key, value));
        }

        return statisticsList;
    }

    private void HandleAuthenticationSuccess(string responseData, object cbObject, AuthenticationRequestCompleted authenticationRequestCompleted)
    {
        // Read the player name from the response data
        JsonData jsonData = JsonMapper.ToObject(responseData);
        userName = jsonData["data"]["playerName"].ToString();

        if (authenticationRequestCompleted != null)
            authenticationRequestCompleted();
    }
}
