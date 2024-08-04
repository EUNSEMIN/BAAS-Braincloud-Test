using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsManager : MonoBehaviour
{
    public static StatisticsManager instance;

    private List<Statistic> statistics;

    private void Awake()
    {
        instance = this;
    }

    public Statistic GetStatisticByName(string name)
    {
        if (statistics != null)
            for (int i = 0; i < statistics.Count; i++)
                if (statistics[i].Name == name)
                    return statistics[i];
        return null;
    }

    public Statistic GetStatisticAtIndex(int index)
    {
        if (statistics != null)
            if (index >= 0 && index < GetCount())
                return statistics[index];
        return null;
    }

    public int GetCount()
    {
        return statistics.Count;
    }

    public void SetStatistics(ref List<Statistic> statistics)
    {
        this.statistics = statistics;
    }

    public Dictionary<string, object> GetIncrementsDictionary()
    {
        if (statistics != null)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();

            for (int i = 0; i < statistics.Count; i++)
            {
                // Add the statistic's name and increment to the dictionary
                data.Add(statistics[i].Name, statistics[i].Increment);
            }

            return data;
        }

        return null;
    }
}
