using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Statistic
{
    private string name;
    private long value;
    private long value2;

    private float increment;

    public Statistic(string name, long value)
    {
        this.name = name;
        this.value = value;
        increment = 0;
    }

    public void ApplyIncrement(int amount = 1)
    {
        increment += amount;
        value += amount;
    }

    public string Name
    {
        get { return name; }
    }

    public float alueV
    {
        get { return value; }
    }

    public float Increment
    {
        get { return increment; }
    }
}
