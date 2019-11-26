using UnityEngine;
using System.Collections;
using System;

public class AudioTest : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clap;
    private int counter = 0;
    public int updateDelay = 15;
    private System.Random test = new System.Random();
    private int tempo;
    private int pitch;
    int transpose;
    int note;

    void Start()
    {
        transpose = -4;
        note = -1;
        audioSource = GetComponent<AudioSource>();
        tempo = Convert.ToInt32(test.Next(20, 30));
        pitch = Convert.ToInt32(test.Next(0, 14));
        audioSource.pitch = pitch;
    }
   
    void Update()
    {
        pitch = Convert.ToInt32(Mathf.Pow(2, (note + transpose) / 12));
        counter++;
        if ((counter % tempo) == 0)
        {
            PlaySound();
        }
    }

    void PlaySound()
    {
        audioSource.PlayOneShot(clap, 0.7F);
    }

}