///
///By: Dhruv 
///Date: 11/4/2020
///Desc: Script to play sound
///

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip impact;
    AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(impact, 0.7f);
        }
    }

//    void OnCollisionEnter2D()
//    {
//        audiosource.PlayOneShot(impact, 0.7f);   
//    }
}
