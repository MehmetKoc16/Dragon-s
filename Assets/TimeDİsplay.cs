using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeDİsplay : MonoBehaviour
{
    float second =0;
    float minute = 0;
    void Update()
    {
        second += Time.deltaTime;
        if (second >= 60)
        {
            minute++;
            second = 0;
        }
        GetComponent<TextMeshProUGUI>().text = string.Format(" Time {0:00}:{1:00}", minute,second);
    }
}
