using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Beat : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip beat;
    public AudioClip stitch;
    private int counter = 0;
    private System.Random random = new System.Random();
    private int tempo;
    private float pitchChange;
    private int noteRange;
    private int doubleNoteCounter;
    private int raisePitch;
    void Start()
    {
        noteRange = random.Next(1,8); //Generates a power value for the pitch, to determine how many semitones will be added to the current value based on random choice
        pitchChange = Mathf.Pow((float)1.05946, noteRange); //multiplying a frequency by 1.05946 to the power of a number raises the frequency by in semitiones dependant on the number - e.g. a C note *1.05946^2 would result in a D note.
        audioSource = GetComponent<AudioSource>();
        tempo = (random.Next(50, 60)); 
        audioSource.pitch = audioSource.pitch * pitchChange; //Multiplies frequency by pitchchange value
    }

void Update()
    {
        doubleNoteCounter = (random.Next(1, 3)); //doubleNoteCounter generates a random number between 1 and 3
        raisePitch = random.Next(1, 3); //upAndDownPitch does the same
        counter++;
        if ((counter % tempo) == 0)
        {
            if (raisePitch.Equals(1)) //if upAndDownPitch's randomly generated number is 1, the pitch will raise up half a note
            {
                audioSource.pitch = audioSource.pitch * (pitchChange / 2); //a full note was too radical a change to be done on average once every three beats.
            }
            PlaySound();

            if (doubleNoteCounter.Equals(1)) //if the number generated is equal to 1, then the PauseThenPlaySound function is used
            {
                StartCoroutine(PauseThenPlaySound());
                PauseThenPlaySound();
                StopCoroutine(PauseThenPlaySound());
                audioSource.pitch = audioSource.pitch / (pitchChange / 2); //the current note is lowered by half a note to counteract the earlier pitch raise

            }
            RecordAudio.Save("Sound", beat);
        }
    }

    void PlaySound()
    {
        audioSource.PlayOneShot(beat);
    }

    IEnumerator PauseThenPlaySound() 
    {
        yield return new WaitForSeconds(pitchChange); //Waits for a number of seconds defined by the pitchChange value for a consistant beat to play

        PlaySound();
    }
}