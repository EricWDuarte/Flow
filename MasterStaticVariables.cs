using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterStaticVariables : MonoBehaviour
{
    MasterStaticVariables instance;
    public static int Highscore = 1000;
    public static bool sound = true;
    private static bool startedMusicOnce = false;
    void Awake()
    {
        MakeSingleton();
        if (startedMusicOnce == false)
        {
            GetComponent<AudioSource>().Play();
            startedMusicOnce = true;
        }

    }

    // Update is called once per frame
    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Mute ()
    {
        sound = !sound;
    }
}
