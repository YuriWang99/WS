using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Players;
    float turnSpeed = 1f;
    void Start()
    {
        Players = GameObject.Find("FPEPlayerController(Clone)");



    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Players.transform);
    }
}
