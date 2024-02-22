using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StatManager : MonoBehaviour
{
    public List<Stat> stats;

    private void Start()
    {
        // Initialize each stat's value to 50
        foreach (Stat stat in stats)
        {
            stat.value = 50;
            UpdateCircle(stat);
            Debug.Log(name + " value set to " + stat.value); // Add this line
        }
    }

    public void UpdateCircle(Stat stat)
    {
        float scale = stat.value / 100f;
        stat.circle.rectTransform.localScale = new Vector3(scale, scale, 1);
        Debug.Log(name + " value updated to " + stat.value);
    }
}


