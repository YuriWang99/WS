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
    [Header("Part1")]
    public GameObject Ele_Door_Light;
    public GameObject Ele_Door_Trigger;
    [Header("Part2")]
    public GameObject PosterLights;
    public GameObject GateLight;
    public GameObject BathroomLight;
    public GameObject Deer;

    void Start()
    {
        StartCoroutine(ElevatorSubtitle());
        Ele_Door_Trigger.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ElevatorSubtitle()
    {
        //Talking in elevator
        SubTitle.color = Color.yellow;
        yield return new WaitForSeconds(2);
        Ele_Door_Light.SetActive(true);
        yield return new WaitForSeconds(3);
        SubTitle.text = "hey cheer up， 今天是上学的第一天";
        yield return new WaitForSeconds(3);
        SubTitle.text = "当时的我一个人从中国来到纽约 hey 我居然把这个记录了下来";
        yield return new WaitForSeconds(3);
        SubTitle.text = "oh，shit，第一天的orientation就迟到，希望没有错过什么东西";
        //dear
        yield return new WaitForSeconds(3);
        SubTitle.color = Color.green;
        SubTitle.text = "今天是上课第一天，luke不希望自己迟到";

        SubTitle.color = Color.yellow;
        yield return new WaitForSeconds(3);
        SubTitle.text = "我为什么在这里";

        Ele_Door_Trigger.SetActive(true);
        
        // end subtitle
        SubTitle.color = Color.yellow;
        SubTitle.text = "";

    }

    public void StartPart2()
    {
        StartCoroutine(Part2Subtitle());
    }
    IEnumerator Part2Subtitle()
    {
        //Talking in elevator
        //PosterLights.SetActive(true);
        
        SubTitle.color = Color.yellow;
        yield return new WaitForSeconds(1);
        SubTitle.text = "Luke这是第一天来到Game Center university， 他感觉到了非常的紧张 这是一个mfa项目";
        yield return new WaitForSeconds(2);
        SubTitle.text = "很多的独立游戏开发者聚到了一起，是一个非常令人兴奋的消息";
        yield return new WaitForSeconds(2);
        SubTitle.text = "我到底是谁，我的名字是什么";
        yield return new WaitForSeconds(2);
        GateLight.SetActive(true);
        SubTitle.text = "对哦，我的校园卡还在审核中，没有批下来";

        yield return new WaitForSeconds(2);
        SubTitle.text = "我为什么在这里";

        Deer.SetActive(true);

        // end subtitle
        SubTitle.color = Color.yellow;
        SubTitle.text = "";

    }
    public void StartPart2Deer()
    {
        StartCoroutine(Part2Deer());
    }
    IEnumerator Part2Deer()
    {
        yield return new WaitForSeconds(3);
        SubTitle.text = "Go find the key in bathroom";
        BathroomLight.SetActive(true);
    }

    public void DestroyPart2Deer()
    {
        StartCoroutine(DesPart2Deer());
    }
    IEnumerator DesPart2Deer()
    {
        yield return new WaitForSeconds(0);
        BathroomLight.SetActive(false);
    }
}
