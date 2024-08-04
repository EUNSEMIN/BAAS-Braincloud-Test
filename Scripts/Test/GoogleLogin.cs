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
        PlayGamesPlatform.Activate();//구글플레이 플랫폼 활성화
        //위의 함수를 실행하면 Social.Active= PlayGamesPlatform.Instance가 된다
    }
    public void Login()//구글플레이 로그인 버튼에 적용
    {
        Social.localUser.Authenticate
        (
            (bool success) =>
            {    
                if(success)//성공시에
                {
                    StartCoroutine("LoadMain");
                }
            }
        );
    }
    IEnumerator LoadMain()//구글플레이 로그인 성공하고 4초 이따가 Main화면 불러들임
    {
        yield return new WaitForSecondsRealtime(4.0f);
        SceneManager.LoadScene("Main");
    }
}
    */
}
