using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Whilefun.FPEKit;

public class NotifationLightControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject NotifationLight;
    public GameObject ElevatorGame;
    public GameObject Door1;
    public GameObject Door2;
    public AudioSource ElevatorAudio;
    //public bool KeepOpen = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PressButton()
    {
        StartCoroutine(ActiveLight());
    }
    IEnumerator ActiveLight()
    {
        //ElevatorGame.GetComponent<ElevatorGameControl>().Demo = false;

        ElevatorAudio.Play();
        NotifationLight.SetActive(true);
        ElevatorGame.GetComponent<ElevatorGameControl>().InputSequence.Add(System.Convert.ToInt32(this.gameObject.name));
        yield return new WaitForSeconds(0);
        //NotifationLight.SetActive(false);
        //ElevatorGame.GetComponent<ElevatorGameControl>().InputSequence.Remove(this.gameObject.name);

    }
    public void CloseTheDoor()
    {
        Door1.GetComponent<FPESlidingDoor>().RemotelyCloseDoor();
        Door2.GetComponent<FPESlidingDoor>().RemotelyCloseDoor();
        NotifationLight.SetActive(false);
        //ElevatorGame.GetComponent<ElevatorGameControl>().InputSequence.Remove(System.Convert.ToInt32(this.gameObject.name));
        //reset
        //KeepOpen = false;
    }
    public void DelayCloseTheDoor()
    {
        StartCoroutine(DelayClose());
    }
    IEnumerator DelayClose()
    {
        yield return new WaitForSeconds(2);
        Door1.GetComponent<FPESlidingDoor>().RemotelyCloseDoor();
        Door2.GetComponent<FPESlidingDoor>().RemotelyCloseDoor();
        NotifationLight.SetActive(false);
        //reset
        //KeepOpen = false;
    }
    public void PlayDemo()
    {
        StartCoroutine(DelayPlayDemo());
    }
    IEnumerator DelayPlayDemo()
    {
        ElevatorAudio.Play();
        NotifationLight.SetActive(true);      
        yield return new WaitForSeconds(2);
        NotifationLight.SetActive(false);
    }
}
