using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BrainCloud;

public class LoginController : MonoBehaviour
{
    private Data data;

    [SerializeField]
    private List<TMP_InputField> inputFeilds;

    public void Start()
    {
        data = DataManager.Instance.data;
    }

    //Login Btn
    public void ClickLoginBtn()
    {
        //Save user data
        data.userData.Id = inputFeilds[0].text;
        data.userData.Pwd= inputFeilds[1].text;
        data.userData.nickName= inputFeilds[2].text;

        //Authentication
        if (Network.instance.HasAuthenticatedPreviously())
        {
            Network.instance.Reconnect();
        }
        else
        {
            Network.instance.RequestAuthenticationUniversal(data.userData.Id, data.userData.Pwd);
        }
    }

    //Set Nickname  
    public void ClickNicknameBtn()
    {
        Network.instance.RequestUpdateUsername(data.userData.nickName);
    }

    //Logout 
    public void ClickLogoutBtn()
    {
        Network.instance.LogOut();
    }
}
