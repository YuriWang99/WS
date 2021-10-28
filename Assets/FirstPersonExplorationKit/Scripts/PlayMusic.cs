using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource Song;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayTheMusic()
    {
        if(Song.isPlaying)
        {
            Song.Stop();
        }
        else
        {
            Song.Play();
        }

    }
}
