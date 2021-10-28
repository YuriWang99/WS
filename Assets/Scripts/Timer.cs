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

    public bool One30 = true, One15=true, One10=true, One0=true;
    void Start()
    {
        TimerTextPro.text = timeStart.ToString("00:00");
        FortyFiveSeconds.Play();
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
            if (timeStart >30&& timeStart < 31)
            {
                play30();
            }
            if (timeStart > 15 && timeStart < 16)
            {
                play15();
            }
            if (timeStart > 10 && timeStart < 11)
            {
                once = false;
                TenSecondsLeft.SetActive(true);
                play10();
            }
            if (timeStart<0)
            {
                timeStart = 0;
                TimerTextPro.text = "00.00";
                inLibrary = false;

                StartCoroutine(PlayText());
            }
        }
    }

    IEnumerator PlayText()
    {
        play0();
        yield return new WaitForSeconds(5f);
        TimeUpText.SetActive(true);
    }
    void play30()
    {
        if (One30)
        {
            ThirtySeconds.Play();
            One30 = false;
        }

    }
    void play15()
    {
        if (One15)
        {
            FifteenSeconds.Play();
            One15 = false;
        }

    }
    void play10()
    {
        if (One10)
        {
            Tenseconds.Play();
            One10 = false;
        }

    }
    void play0()
    {
        if (One0)
        {
            Passward.Play();
            One0 = false;
        }

    }
}
