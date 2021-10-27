using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class SubTitleSystem : MonoBehaviour
{
    // Start is called before the first frame update
    //Part1
    [Header("General")]
    public TMP_Text SubTitle;
    public AudioSource BGM;
    public AudioSource PipeBGM;
    [Header("Part1")]
    public GameObject Ele_Door_Light;
    public GameObject Ele_Door_Trigger;
    public GameObject[] Floors;
    public AudioSource ElevatorOpen;
    int CurrentFloor = 0;
    [Header("Part2")]
    //public GameObject PosterLights;
    //public GameObject GateLight;
    //public GameObject BathroomLight;
    //public GameObject AreaLights;
    //public GameObject Deer;
    [Header("Part4")]
    //public GameObject GrassDeer;
    //public GameObject Audio626;
    public GameObject Furnicture;
    [Header("Text file")]
    public TextAsset Part1;
    
    public int index;

    public float textSpeed;
    bool textFinished;
    bool startSubtotle;

    List<string> textList = new List<string>();

    [Header("Text gameobjects")]
    public GameObject Part2;
    void Awake()
    {
        BGM.Play();
        GetTextFromFile(Part1);
        index = 0;
    }
    private void OnEnable()
    {
        /*textLabel.text = textList[index];
        index++;*/
        textFinished = true;
    }

    void Start()
    {
        //StartCoroutine(ElevatorSubtitle());
        Ele_Door_Trigger.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Floors.Length; i++)
        {
            if (i == CurrentFloor)
            {
                Floors[i].SetActive(true);
            }
            else
            {
                Floors[i].SetActive(false);
            }
        }
        if(startSubtotle)
        {
            //Counter
            if (index == textList.Count)
            {
                //gameObject.SetActive(false);
                index = 0;
                startSubtotle = false;
                return;
            }
            if (textFinished)
            {
                /*textLabel.text = textList[index];
                index++;*/
                StartCoroutine(SetTextUI());
            }
        }


    }
    public void StartPart1()
    {
        startSubtotle = true;
        StartCoroutine(ElevatorPart1Subtitle());
    }
    IEnumerator ElevatorPart1Subtitle()
    {
        //Talking in elevator
        //BGM.Play();
        SubTitle.color = Color.yellow;
        yield return new WaitForSeconds(2);
        Ele_Door_Light.SetActive(true);
        yield return new WaitForSeconds(2);
        CurrentFloor = 1;
        yield return new WaitForSeconds(4);
        yield return new WaitForSeconds(4);
        CurrentFloor = 2;
        yield return new WaitForSeconds(4);
        yield return new WaitForSeconds(4);
        CurrentFloor = 3;
        yield return new WaitForSeconds(4); 
        yield return new WaitForSeconds(4);
        CurrentFloor = 4;
        yield return new WaitForSeconds(4);
        yield return new WaitForSeconds(4);
        //SubTitle.text = "He didn't know how to get out of this elevator next.";
        CurrentFloor = 5;
        ElevatorOpen.Play();

        //Elevator Audio
        Ele_Door_Trigger.SetActive(true);

        // end subtitle
        yield return new WaitForSeconds(2);
        SubTitle.color = Color.yellow;
        SubTitle.text = "";

    }

    public void StartPart2()
    {
        if(!Part2.activeSelf)
        {
            Part2.SetActive(true);
        }
        //StartCoroutine(Part2Subtitle());
    }
    IEnumerator Part2Subtitle()
    {
        startSubtotle = true;
        yield return new WaitForSeconds(2);

    }
    public void StartPart3()
    {
        StartCoroutine(Part3Subtitle());
    }
    IEnumerator Part3Subtitle()
    {
        SubTitle.color = Color.yellow;
        yield return new WaitForSeconds(4);
        SubTitle.text = "But really come in, luke long-lost feel a trace of excitement and surprise,";
        yield return new WaitForSeconds(4);
        SubTitle.text = "he liked the past time to study here, and in reality he did not go back once,";
        yield return new WaitForSeconds(4);
        SubTitle.text = "at the moment a strange and familiar mixed feeling rushed to luke's heart.";
        yield return new WaitForSeconds(4);
        SubTitle.text = "Into the school inside the luke found it really empty, he could only choose to look around, looking for clues to get out.";
        yield return new WaitForSeconds(4);
        SubTitle.text = "It's the weekend, Luke has many questions,although there is no person here,but many students' work on the table.";
        yield return new WaitForSeconds(4);
        SubTitle.text = "This feeling is very familiar, because Luke used to put his own work in the past just like this here.";

        //End subtitle
        yield return new WaitForSeconds(2);
        SubTitle.color = Color.yellow;
        SubTitle.text = "";
    }
    public void StartPart4()
    {
        StartCoroutine(Part4Subtitle());
    }
    IEnumerator Part4Subtitle()
    {
        //watched all the posters
        SubTitle.color = Color.yellow;
        yield return new WaitForSeconds(2);
        SubTitle.text = "It looks like these games are really well done, and luke feels like he couldn't have come up with such a great idea when he was in school.";
        yield return new WaitForSeconds(4);
        SubTitle.text = "But where has everyone gone?";
        yield return new WaitForSeconds(4);
        //Audio626.SetActive(true);
        
        //(but luke just ready to use the password to open the door when the very bright lounge suddenly lights all down,
        //a moment later,
        //the light behind it like the sun shone up, and luke where the darkness formed a clear contrast,
        //all the tables and chairs all gone, the ground into the grass, a deer standing on the grass)
        //Furnicture.SetActive(false);
        //GrassDeer.SetActive(true);
        yield return new WaitForSeconds(4);
        SubTitle.text = "It's a deer.";
        yield return new WaitForSeconds(4);
        SubTitle.text = "Yes, that's right. A gentle moose is standing not far away at the moment, without any expression or movement, and she can even see the grass by her feet, which just looks incredible.";
        yield return new WaitForSeconds(4);
        SubTitle.text = "Luke stepped forward without any hesitation.";

        //End subtitle
        yield return new WaitForSeconds(2);
        SubTitle.color = Color.yellow;
        SubTitle.text = "";

    }
    public void StartTalkWithDeer()
    {
        StartCoroutine(TalkWithDeer());
    }
    IEnumerator TalkWithDeer()
    {
        yield return new WaitForSeconds(2);
        SubTitle.text = "deer, I'm glad you showed up.";
        yield return new WaitForSeconds(4);
        SubTitle.text = "So it's the same old thing again, right, it's just a dream and I need to find something crucial in this dream to wake up, right?";
        yield return new WaitForSeconds(4);
        SubTitle.text = "It's really the same old plot, and going back to the place where you used to go to graduate school is not a fun dream.";
        yield return new WaitForSeconds(4);
        SubTitle.text = "Her name is deer, and she is luke's best friend.";
        yield return new WaitForSeconds(4);
        SubTitle.text = "Luke usually talks to deer about his troubles, and deer gives Luke positive guidance in a silent way. luke is very grateful for all this.";
        yield return new WaitForSeconds(4);
        SubTitle.text = "Although deer only appear in dreams.";
        yield return new WaitForSeconds(4);
        //End subtitle
        yield return new WaitForSeconds(2);
        SubTitle.color = Color.yellow;
        SubTitle.text = "";
    }

    public void StartPart2Deer()
    {
        StartCoroutine(Part2Deer());
    }
    IEnumerator Part2Deer()
    {
        yield return new WaitForSeconds(0);
        SubTitle.text = "Go find the key in bathroom";
        //BathroomLight.SetActive(true);
    }

    public void DestroyPart2Deer()
    {
        StartCoroutine(DesPart2Deer());
    }
    IEnumerator DesPart2Deer()
    {
        yield return new WaitForSeconds(0);
        //Deer.SetActive(false);
        //PosterLights.SetActive(true);
        //AreaLights.SetActive(true);
    }

    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var linData = file.text.Split('\n');

        foreach (var line in linData)
        {
            textList.Add(line);
        }
    }
    IEnumerator SetTextUI()
    {
       
        textFinished = false;
        SubTitle.text = "";
        for (int i = 0; i < textList[index].Length; i++)
        {
            SubTitle.text += textList[index][i];
            yield return new WaitForSeconds(textSpeed);
            if(i== textList[index].Length-1)
            {
                yield return new WaitForSeconds(2);
            }
        }
        textFinished = true;
        //yield return new WaitForSeconds(4);
        index++;
    }

    public void SwitchBGM()
    {
        BGM.Stop();
        PipeBGM.Play();
    }
}
