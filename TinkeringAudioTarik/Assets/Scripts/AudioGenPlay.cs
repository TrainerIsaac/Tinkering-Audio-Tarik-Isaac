using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class AudioGenPlay : MonoBehaviour
{
    // Variables for min and max range of random generation - available from editor.
    public int ErrRangeMin = 300;
    public int ErrRangeMax = 330;
    public int SuccRangeMin = 440;
    public int SuccRangeMax = 500;

    public float ErrFreq;
    public float SuccFreq;

    // Play an error sound.
    public void PlayError()
    {
        // Assigning values to variables.
        ErrFreq = new System.Random().Next(ErrRangeMin, ErrRangeMax);
        AudioSource audio = GetComponent<AudioSource>();

        int sampleFreq = 44100;
        float[] samples = new float[11025];

        // Generating tone.
        for (int i = 0; i < samples.Length; i++)
        {
            samples[i] = Mathf.Repeat(i * ErrFreq / sampleFreq, 1) * 2f - 1f;
        }

        // Assigning tone.
        AudioClip audPlay = AudioClip.Create("Test", samples.Length, 1, sampleFreq, false);
        audPlay.SetData(samples, 0);

        audio.clip = audPlay;

        // Play generated tone.
        audio.Play();
    }

    // Play a seccess sound.
    public void PlaySuccess()
    {
        // Assigning values to variables.
        SuccFreq = new System.Random().Next(SuccRangeMin, SuccRangeMax);
        AudioSource audio = GetComponent<AudioSource>();

        int sampleFreq = 44100;
        float[] samples = new float[11025];

        // Generating tone.
        for (int i = 0; i < samples.Length; i++)
        {
            samples[i] = Mathf.PingPong(i * 2f * SuccFreq / sampleFreq, 1) * 2f - 1f;
        }

        // Assigning tone.
        AudioClip audPlay = AudioClip.Create("Test", samples.Length, 1, sampleFreq, false);
        audPlay.SetData(samples, 0);

        audio.clip = audPlay;

        // Play generated tone.
        audio.Play();
    }

}
