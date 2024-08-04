using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UserData 
{
    public string Id { get; set; }
    public string Pwd { get; set; }
    public string nickName { get; set; }

    public int Hp { get; set; }
    public int Xp { get; set; }
    public int score { get; set; }
    public int level{ get; set; }

    public string division { get; set; }
    public string division_st { get; set; }

    public string tournament { get; set; }

    public void Start()
    {
        Network.instance.GetMyDivision();
    }
}

