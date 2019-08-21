using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHitSFX : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource afterSource;
    public AudioClip hit;
    public AudioClip after;

    public static WallHitSFX instance;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit (float intensity)
    {
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.PlayOneShot(hit, 0.2f + intensity/25f);
        afterSource.PlayOneShot(after, 0.1f + intensity/20f);
    }
}
