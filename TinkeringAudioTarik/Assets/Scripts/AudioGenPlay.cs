using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class AudioGenPlay : MonoBehaviour
{
    //TODO:
    //* Add comments

    
    public float ErrFreq;
    public float SuccFreq;

    // Play an error sound.
    public void PlayError()
    {
        ErrFreq = new System.Random().Next(300, 330);
        AudioSource audio = GetComponent<AudioSource>();

        int sampleFreq = 44100;
        float[] samples = new float[11025];

        for (int i = 0; i < samples.Length; i++)
        {
            samples[i] = Mathf.Repeat(i * ErrFreq / sampleFreq, 1) * 2f - 1f;
        }

        AudioClip audPlay = AudioClip.Create("Test", samples.Length, 1, sampleFreq, false);
        audPlay.SetData(samples, 0);

        audio.clip = audPlay;

        audio.Play();
    }

    // Play a seccess sound.
    public void PlaySuccess()
    {
        SuccFreq = new System.Random().Next(440, 550);
        AudioSource audio = GetComponent<AudioSource>();

        int sampleFreq = 44100;
        float[] samples = new float[11025];

        for (int i = 0; i < samples.Length; i++)
        {
            samples[i] = Mathf.PingPong(i * 2f * SuccFreq / sampleFreq, 1) * 2f - 1f;
        }

        AudioClip audPlay = AudioClip.Create("Test", samples.Length, 1, sampleFreq, false);
        audPlay.SetData(samples, 0);

        audio.clip = audPlay;

        audio.Play();
    }

}
