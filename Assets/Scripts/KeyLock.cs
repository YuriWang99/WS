using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLock : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool IsInputEnabled = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Lock15s()
    {
        StartCoroutine(Delay15s());
    }
    IEnumerator Delay15s()
    {
        yield return new WaitForSeconds(15);
    }
}
