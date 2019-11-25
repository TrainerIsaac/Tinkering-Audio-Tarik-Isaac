using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioGenPlay : MonoBehaviour
{

    public void PlayOnClick()
    {
        AudioSource audio = GetComponent<AudioSource>();
        System.Random rnd = new System.Random();
        int sampleFreq = 44100;
        float frequency = rnd.Next(440, 660);

        float[] samples = new float[44100];

        for (int i = 0; i < samples.Length; i++)
        {
            samples[i] = Mathf.Repeat(i * frequency / sampleFreq, 1) * 2f - 1f;
        }

        AudioClip audPlay = AudioClip.Create("Test", samples.Length, 1, sampleFreq, false);
        audPlay.SetData(samples, 0);

        audio.clip = audPlay;

        audio.PlayOneShot(audPlay);
    }

}
