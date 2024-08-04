using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using BrainCloud.LitJson;

public class LevelData 
{
    private int xp;
    private int hp;

    private string ex;

    public LevelData(ref JsonData data)
    {
        ex = data["Level"].ToString();
        Debug.Log(ex);
    }
}
