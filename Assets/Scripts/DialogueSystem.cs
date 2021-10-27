using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    [Header("UI组件")]
    public TMP_Text textLabel;
    public GameObject SubtitleController;
    public bool DisplayText = false;

    [Header("文本文件")]
    public TextAsset textFile;
    public int index;
    public float textSpeed;
    bool textFinished;

    [Header("关联object")]
    //public GameObject B_Arrows;

    List<string> textList = new List<string>();

    //public AudioSource writing;//按钮声音
    void Awake()
    {
        GetTextFromFile(textFile);
    }
    private void OnEnable()
    {
        /*textLabel.text = textList[index];
        index++;*/
        //StartCoroutine(SetTextUI());

        //writing.Play();
        if (!SubtitleController.GetComponent<SubtitleController>().hasSubtitle)
        {
            DisplayText = true;
            SubtitleController.GetComponent<SubtitleController>().hasSubtitle = true;
            StartCoroutine(SetTextUI());
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (DisplayText && index >= textList.Count && textFinished)
            {
                index = 0;
                textFinished = false;
            SubtitleController.GetComponent<SubtitleController>().hasSubtitle = false;
            DisplayText = false;
            this.gameObject.SetActive(false);

            }
            if (DisplayText && textFinished)
            {
                
                /*textLabel.text = textList[index];
                index++;*/
                StartCoroutine(SetTextUI());
            }

    }
    public void StartDisplay()
    {

    }

    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lineData = file.text.Split('\n');

        foreach (var line in lineData)
        {
            textList.Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        //writing.Play();
        textFinished = false;
        textLabel.text = "";

        for (int i = 0; i < textList[index].Length; i++)
        {
            textLabel.text += textList[index][i];
            yield return new WaitForSeconds(textSpeed);
        }

        //writing.Stop();
        yield return new WaitForSeconds(2f);
        textFinished = true;
        index++;
    }
}
