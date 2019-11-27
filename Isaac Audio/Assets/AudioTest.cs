﻿using UnityEngine;
using System.Collections;
using System;

public class AudioTest : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip note;
    private int counter = 0;
    public int updateDelay = 15;
    private System.Random random = new System.Random();
    private int tempo;
    private float pitchChange;
    private int noteRange;

    void Start()
    {
        noteRange = random.Next(-20,8); //Generates a power value for the pitch, to determine how many semitones will be added to the current value based on random choice
        pitchChange = Mathf.Pow((float)1.05946, noteRange); //multiplying a frequency by 1.05946 to the power of a number raises the frequency by in semitiones dependant on the number - e.g. a C note *1.05946^2 would result in a D note.
        audioSource = GetComponent<AudioSource>();
        tempo = Convert.ToInt32(random.Next(20, 30)); 
        audioSource.pitch = audioSource.pitch * pitchChange; //Multiplies frequency by pitchchange value
    }
   
    void Update()
    {
        counter++;
        if ((counter % tempo) == 0)
        {
            PlaySound();
        }
    }

    void PlaySound()
    {
        audioSource.PlayOneShot(note, 0.7F);
    }

}