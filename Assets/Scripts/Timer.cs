using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    // Time Slider
    public float timeStart = 45;//seconds 720s
    public float totalTime;
    public int Hour;
    public int Minute;
    public TMP_Text TimerTextPro;

    public bool inLibrary;
    bool once = true;
    public GameObject TenSecondsLeft;

    public AudioSource Tenseconds;
    public AudioSource Passward;
    void Start()
    {
        TimerTextPro.text = timeStart.ToString("00:00");
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
            if(timeStart<10&& once)
            {
                once = false;
                TenSecondsLeft.SetActive(true);
                Tenseconds.Play();
            }

            if(timeStart<0)
            {
                timeStart = 0;
                TimerTextPro.text = "00.00";
                inLibrary = false;
                Passward.Play();
            }

        }


    }
}
