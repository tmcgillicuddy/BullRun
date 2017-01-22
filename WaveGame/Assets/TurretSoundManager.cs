using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSoundManager : MonoBehaviour {
    AudioClip lastClip = null;
    public AudioClip[] pews;

    public AudioClip returnPew()
    {
        AudioClip temp = null;
        int i = Random.Range(0, pews.Length-1);

        if (pews[i] == lastClip)
        {
            if (i == pews.Length)
            {
                temp = pews[i - 1];
            }
            else
            {
                temp = pews[i + 1];
             }
        }
        else
        {
            temp = pews[i];
        }
        lastClip = temp;
        return temp;
        
    }    
}
