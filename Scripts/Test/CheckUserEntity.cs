using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class CheckUserEntity : MonoBehaviour
{
    private Data data;

    [SerializeField]
    private TMP_Text name;

    private void Start()
    {
        data = DataManager.Instance.data;
    }

}
