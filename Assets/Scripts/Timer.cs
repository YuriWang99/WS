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
    public GameObject TimeUpText;

    public AudioSource TimeStarts;
    public AudioSource FortyFiveSeconds;
    public AudioSource ThirtySeconds;
    public AudioSource FifteenSeconds;
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
            //720 24h »»Ëã 30s = 1h 30s = 60min 1s = 2 min
            timeStart -= Time.deltaTime;
            TimerTextPro.text = timeStart.ToString("00.00");// Timer font 00:00
            if(timeStart>44)
            {
                once = false;
                FortyFiveSeconds.Play();
            }
            else if (timeStart >30)
            {
                once = false;
                ThirtySeconds.Play();
            }
            else if (timeStart < 15 && once)
            {
                once = false;
                FifteenSeconds.Play();
            }
            else if (timeStart < 10 && once)
            {
                once = false;
                TenSecondsLeft.SetActive(true);
                Tenseconds.Play();
            }

            if (timeStart<0)
            {
                timeStart = 0;
                TimerTextPro.text = "00.00";
                inLibrary = false;
                Passward.Play();
                StartCoroutine(PlayText());
            }

        }


    }

    IEnumerator PlayText()
    {
        yield return new WaitForSeconds(3f);
        TimeUpText.SetActive(true);
    }
}
