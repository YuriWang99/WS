using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerOnlyCount : MonoBehaviour
{
    public float timeStart = 45;//seconds 720s
    public float totalTime;
    public int Hour;
    public int Minute;
    public TMP_Text TimerTextPro;
    public bool inLibrary;
    void Start()
    {
        TimerTextPro.text = timeStart.ToString("00:00");
        //FortyFiveSeconds.Play();
        inLibrary = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (inLibrary)
        {
            //720 24h ªªÀ„ 30s = 1h 30s = 60min 1s = 2 min
            timeStart -= Time.deltaTime;
            TimerTextPro.text = timeStart.ToString("00.00");// Timer font 00:00

            if (timeStart < 0)
            {
                timeStart = 0;
                TimerTextPro.text = "00.00";
                inLibrary = false;
            }
        }
    }
}
