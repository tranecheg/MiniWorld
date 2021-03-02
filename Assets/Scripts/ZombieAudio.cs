using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAudio : MonoBehaviour
{
    public AudioClip[] clips;
    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        StartCoroutine(spawnAudio());
    }

    IEnumerator spawnAudio()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(10,15));
            AudioClip nowClip = clips[Random.Range(0, clips.Length)];
            audio.clip = nowClip;
            audio.Play();
            
        }
    }
    
}
