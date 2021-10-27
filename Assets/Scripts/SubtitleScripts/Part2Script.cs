using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Part2Script : MonoBehaviour
{
    [Header("UI components")]
    public TMP_Text Part2;

    [Header("Text file")]
    public TextAsset textFile;
    public int index;

    public float textSpeed;
    bool textFinished;

    bool PlayText = false;

    List<string> textList = new List<string>();
    void Awake()
    {
        GetTextFromFile(textFile);
        index = 0;
    }

    private void OnEnable()
    {
        /*textLabel.text = textList[index];
        index++;*/
        textFinished = true;
        StartCoroutine(SetTextUI());
    }
    // Update is called once per frame
    void Update()
    {
        if (PlayText && index == textList.Count)
        {
            gameObject.SetActive(false);
            PlayText = false;
            index = 0;
            return;
        }
        if (PlayText && textFinished)
        {
            /*textLabel.text = textList[index];
            index++;*/
            StartCoroutine(SetTextUI());
        }
    }
    public void PlayTheText()
    {
        PlayText = true;
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
        Part2.text = "";
        for (int i = 0; i < textList[index].Length; i++)
        {
            Part2.text += textList[index][i];
            yield return new WaitForSeconds(textSpeed);
            yield return new WaitForSeconds(2);
        }
        textFinished = true;
        index++;
    }
}
