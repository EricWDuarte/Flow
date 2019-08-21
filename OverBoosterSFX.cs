using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverBoosterSFX : MonoBehaviour
{
    public static float volume;
    private float decay = 0.005f;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        volume = 0;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        volume *= 0.9f;
        volume -= decay;

        if (volume < 0)
        {
            volume = 0;
        }
        if (volume > 0.3f)
        {
            volume = 0.3f;
        }
        audioSource.volume = volume;
    }
}
