using UnityEngine;
using System.Collections;
using System;

public class RandomSounds : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip tune;
    private int counter = 0;
    private System.Random random = new System.Random();
    private int tempo;
    private float pitchChange;
    private int noteRange;

    void Begin()
    {
        audioSource = GetComponent<AudioSource>();
    }
   
    void LateUpdate()
    {
        noteRange = random.Next(-3, 6); //Generates a power value for the pitch, to determine how many semitones will be added to the current value based on random choice
        pitchChange = Mathf.Pow((float)1.05946, noteRange); //multiplying a frequency by 1.05946 to the power of a number raises the frequency by in semitiones dependant on the number - e.g. a C note *1.05946^2 would result in a D note.
        tempo = (random.Next(30, 40));

        counter++;
        if ((counter % tempo) == 0)
        {
            CreateSound();
        }

        if (audioSource.pitch > 2) 
        {
            LowerPitch();
        }


    }

    void CreateSound()
    {
        audioSource.pitch = audioSource.pitch * pitchChange; //Multiplies frequency by pitchchange value
        audioSource.PlayOneShot(tune);
    }

    void LowerPitch()
    {
        audioSource.pitch = audioSource.pitch / pitchChange;
    }

}