using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GoogleLogin : MonoBehaviour
{
    /*
     using GooglePlayGames;

    public void Start() {
      PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }

    internal void ProcessAuthentication(SignInStatus status) {
      if (status == SignInStatus.Success) {
        // Continue with Play Games Services
      } else {
        // Disable your integration with Play Games Services or show a login button
        // to ask users to sign-in. Clicking it should call
        // PlayGamesPlatform.Instance.ManuallyAuthenticate(ProcessAuthentication).
      }
    }
}
    */


    /*
         public class GoogleLogin : MonoBehaviour
{
    void Start()
    {
        PlayGamesPlatform.DebugLogEnabled=true;   
        PlayGamesPlatform.Activate();//�����÷��� �÷��� Ȱ��ȭ
        //���� �Լ��� �����ϸ� Social.Active= PlayGamesPlatform.Instance�� �ȴ�
    }
    public void Login()//�����÷��� �α��� ��ư�� ����
    {
        Social.localUser.Authenticate
        (
            (bool success) =>
            {    
                if(success)//�����ÿ�
                {
                    StartCoroutine("LoadMain");
                }
            }
        );
    }
    IEnumerator LoadMain()//�����÷��� �α��� �����ϰ� 4�� �̵��� Mainȭ�� �ҷ�����
    {
        yield return new WaitForSecondsRealtime(4.0f);
        SceneManager.LoadScene("Main");
    }
}
    */
}
