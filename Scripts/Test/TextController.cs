using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class TextController : MonoBehaviour
{
    private Data data;

    [SerializeField]
    private TMP_Text division;

    [SerializeField]
    private TMP_Text score;

    [SerializeField]
    private TMP_Text nickname;

    private void Start()
    {
        data = DataManager.Instance.data;

        data.GetUserDivision();
    }

    private void Update()
    {
        division.text = data.userData.division;

        score.text = data.userData.score.ToString();

        nickname.text = data.userData.nickName;
    }







}
