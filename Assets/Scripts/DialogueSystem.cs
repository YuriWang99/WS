using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    [Header("UI components")]
    public TMP_Text textLabel;

    [Header("Text file")]
    public TextAsset textFile;
    public int index;

    public float textSpeed;
    bool textFinished;

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
        if(Input.GetKeyDown(KeyCode.R)&&index==textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }
        if(Input.GetKeyDown(KeyCode.R)&& textFinished)
        {
            /*textLabel.text = textList[index];
            index++;*/
            StartCoroutine(SetTextUI());
        }
    }

    void GetTextFromFile( TextAsset file)
    {
        textList.Clear();
        index = 0;

        var linData = file.text.Split('\n');

        foreach(var line in linData)
        {
            textList.Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        textFinished = false;
        textLabel.text = "";
        for(int i = 0; i< textList[index].Length; i++)
        {
            textLabel.text += textList[index][i];
            yield return new WaitForSeconds(textSpeed);
        }
        textFinished = true;
        index++;
    }
}
