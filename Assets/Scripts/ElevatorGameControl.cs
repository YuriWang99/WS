using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorGameControl : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Elevators")]
    public GameObject[] Elevators;
    //Elevators: 1 2 3 4 5(A) 6(B) 7(C) 8(D)
    public bool GameStart = false;
    [Header("game Check")]
    public int SequenceIndex = 1;
    [Header("Sequence 1: D 4 C")]
    public int[] Sequence1 = { 8, 4, 7 }; //D 4 C
    [Header("Sequence 1: A 3 C 1")]
    public int[] Sequence2 = { 5, 3, 7, 1 }; //A 3 C 1
    [Header("Sequence 1: //B 2 D 1 4 ")]
    public int[] Sequence3 = { 6, 2, 8, 1, 4 }; //B 2 D 1 4 
    public List<int> InputSequence;

    public GameObject YellowLight, GreenLight, RedLight, Light;

    void Start()
    {
        //Demo1();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameStart)
        {
            if (InputSequence.Count > 0)
            {
                //sequence 1
                if (SequenceIndex == 1)
                {
                    if (InputSequence.Count == 3)
                    {
                        if (InputSequence[0] == Sequence1[0] && InputSequence[1] == Sequence1[1]
                            && InputSequence[2] == Sequence1[2])
                        {

                            ClearSequence();
                            Debug.Log("Sequence1 finished");
                            //reset
                            SequenceIndex = 2;

                            Invoke("Demo1", 3f);

                            GreenLight.SetActive(false);
                            YellowLight.SetActive(true);

                            Invoke("Demo2", 10f);

                        }
                        else
                        {
                            ClearSequence();
                            Invoke("Demo1", 3f);
                        }
                    }
                }
                if (SequenceIndex == 2)
                {
                    //Demo2();
                    if (InputSequence.Count == 4)
                    {
                        if (InputSequence[0] == Sequence2[0] && InputSequence[1] == Sequence2[1]
                            && InputSequence[2] == Sequence2[2] && InputSequence[3] == Sequence2[3])
                        {
                            ClearSequence();
                            Debug.Log("Sequence2 finished");
                            //reset
                            SequenceIndex = 3;

                            Invoke("Demo2", 3f);

                            YellowLight.SetActive(false);
                            RedLight.SetActive(true);

                            Invoke("Demo3", 10f);
                        }
                        else
                        {
                            Invoke("Demo2", 5f);
                            Debug.Log("Sequence2 false");
                            ClearSequence();
                        }
                    }
                }
                if (SequenceIndex == 3)
                {
                    if (InputSequence.Count == 5)
                    {
                        if (InputSequence[0] == Sequence3[0] && InputSequence[1] == Sequence3[1]
                            && InputSequence[2] == Sequence3[2] && InputSequence[3] == Sequence3[3]
                            && InputSequence[4] == Sequence3[4])
                        {
                            Invoke("Demo3", 3f);

                            RedLight.SetActive(false);
                            Light.SetActive(true);

                            ClearSequence();
                            Debug.Log("Sequence3 finished");
                            SequenceIndex = 4;
                            GameStart = false;
                            //reset
                        }
                        else
                        {
                            Invoke("Demo3", 5f);
                            Debug.Log("Sequence3 false");
                            ClearSequence();
                        }
                    }
                }
            }

        }

    }

    IEnumerator Counter()
    {
        yield return new WaitForSeconds(3f);
    }
    public void Demo1()
    {
        StartCoroutine(PlayeDemo1());
    }
    IEnumerator PlayeDemo1()
    {
        yield return new WaitForSeconds(1f);
        Elevators[7].GetComponent<NotifationLightControl>().PlayDemo();
        yield return new WaitForSeconds(1f);
        Elevators[3].GetComponent<NotifationLightControl>().PlayDemo();
        yield return new WaitForSeconds(1f);
        Elevators[6].GetComponent<NotifationLightControl>().PlayDemo();
        yield return new WaitForSeconds(1f);

    }

    
    public void Demo2()
    {
        StartCoroutine(PlayeDemo2());
    }
    IEnumerator PlayeDemo2()
    {
        Debug.Log("Play Demo2");
        yield return new WaitForSeconds(1f);
        Elevators[4].GetComponent<NotifationLightControl>().PlayDemo();
        yield return new WaitForSeconds(1f);
        Elevators[2].GetComponent<NotifationLightControl>().PlayDemo();
        yield return new WaitForSeconds(1f);
        Elevators[6].GetComponent<NotifationLightControl>().PlayDemo();
        yield return new WaitForSeconds(1f);
        Elevators[0].GetComponent<NotifationLightControl>().PlayDemo();
    }
    
    public void Demo3()
    {
        StartCoroutine(PlayeDemo3());
    }
    IEnumerator PlayeDemo3()
    {
        yield return new WaitForSeconds(1f);
        Elevators[5].GetComponent<NotifationLightControl>().PlayDemo();
        yield return new WaitForSeconds(1f);
        Elevators[1].GetComponent<NotifationLightControl>().PlayDemo();
        yield return new WaitForSeconds(1f);
        Elevators[7].GetComponent<NotifationLightControl>().PlayDemo();
        yield return new WaitForSeconds(1f);
        Elevators[0].GetComponent<NotifationLightControl>().PlayDemo();
        yield return new WaitForSeconds(1f);
        Elevators[3].GetComponent<NotifationLightControl>().PlayDemo();
    }
    
    
    public void ClearSequence()
    {
        StartCoroutine(ClearSequenceDelay());
    }
    IEnumerator ClearSequenceDelay()
    {

            yield return new WaitForSeconds(2);
            Debug.Log(InputSequence.Count);
            for (int i = 0; i < InputSequence.Count; i++)
            {
                Elevators[InputSequence[i] - 1].GetComponent<NotifationLightControl>().CloseTheDoor();
            }
            InputSequence.Clear();
    }

    public void StartGame()
    {
        GameStart = true;
        Light.SetActive(false);
        GreenLight.SetActive(true);
        Invoke("Demo1", 2f);

    }


} 

