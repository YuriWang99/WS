using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Whilefun.FPEKit;

public class ResetButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CuratinA, CuratinB, CuratinC, CuratinD, CuratinE;
    public List<string> InputButton;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(InputButton.Count==4)
        {
            if(InputButton[0]=="Button3"|| InputButton[0] == "Button1")
            {
                if (InputButton[0] == "Button3" || InputButton[0] == "Button1")
                {
                    //Win
                    CuratinE.GetComponent<FPESlidingDoor>().RemotelyOpenDoor();
                }
            }
        }
    }

    public void Button1()
    {
        CuratinD.GetComponent<FPESlidingDoor>().RemotelyCloseDoor();
        CuratinB.GetComponent<FPESlidingDoor>().RemotelyOpenDoor();
        //DoorB.GetComponent<FPEAlwaysSwingOutDoor>().();
        InputButton.Add("Button1");
    }
    public void Button2()
    {
        CuratinD.GetComponent<FPESlidingDoor>().RemotelyCloseDoor();
        CuratinB.GetComponent<FPESlidingDoor>().RemotelyCloseDoor();
        InputButton.Add("Button2");
    }
    public void Button3()
    {
        CuratinA.GetComponent<FPESlidingDoor>().RemotelyOpenDoor();
        CuratinD.GetComponent<FPESlidingDoor>().RemotelyOpenDoor();
        InputButton.Add("Button3");
    }
    public void Button4()
    {
        CuratinA.GetComponent<FPESlidingDoor>().RemotelyCloseDoor();
        CuratinC.GetComponent<FPESlidingDoor>().RemotelyCloseDoor();
        InputButton.Add("Button4");
    }
    public void ResetButtonFunction()
    {
        CuratinA.GetComponent<FPESlidingDoor>().RemotelyCloseDoor();
        CuratinB.GetComponent<FPESlidingDoor>().RemotelyCloseDoor();
        CuratinC.GetComponent<FPESlidingDoor>().RemotelyOpenDoor();
        CuratinD.GetComponent<FPESlidingDoor>().RemotelyOpenDoor();
        CuratinE.GetComponent<FPESlidingDoor>().RemotelyOpenDoor();
        InputButton.Clear();
    }

}
