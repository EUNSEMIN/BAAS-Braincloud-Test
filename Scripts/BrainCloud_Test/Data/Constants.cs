using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Constants 
{
    public const string mainLeaderboardId = "Main";
    public const int brainCloudDefaultMinScoreIndex = 0;    
    public const int brainCloudDefaultMaxScoreIndex = 9;

    public const string brainCloudGlobalEntityIndexedID = "Division";

    public const string brainCloudStatHp = "HP";
    public const string brainCloudStatPo = "Po";

    public static readonly Dictionary<string, string> brainCloudStatDescriptions = new Dictionary<string, string> {{brainCloudStatHp, "HP"},
                                                                                                                    {brainCloudStatPo, "POWER"} };

    public const string kBrainCloudUserProgressUserEntityType = "Win Num";
    public const string kBrainCloudUserProgressUserEntityDefaultData = "{\"levelOneCompleted\":\"false\",\"levelTwoCompleted\":\"false\",\"levelThreeCompleted\":\"false\",\"levelBossCompleted\":\"false\"}";
    public const string kBrainCloudUserProgressUserEntityDefaultAcl = "{\"other\":1}";
}




