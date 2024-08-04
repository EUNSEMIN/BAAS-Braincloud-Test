using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;
using UnityEngine.Networking;

using BrainCloud.LitJson;

public class GameManager : MonoBehaviour
{
    private Data data;

    #region Singleton

    private static GameManager instance;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            data = DataManager.Instance.data;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Get function
    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    #endregion

    /// <summary>
    /// About UserEntity
    /// </summary>
    /// 

    public void CreateUserEntity()
    {
        Network.instance.CreateUserEntityData();
    }

    public void GetUserEntity()
    {
        Network.instance.RequestUserEntityData("Fail Num", OnRequestUserEntity);
    }

    public void UpdateUserEntityData()
    {
        data.SetUserEntityWinNumJson();
        Network.instance.UpdateUserEntityData(data.entityId, "Fail Num", data.UserEntity_FailNum);
    }

    public void OnRequestUserEntity(ref List<string> entityIds)
    {
        foreach (string entityId in entityIds)
        {
            //Debug.Log("Score: " + entityId);
            //data.entityId = entityId; 
        }
    }

    //Increse score
    public void IncreseUserScore()
    {
        data.userData.score++;
    }
}
