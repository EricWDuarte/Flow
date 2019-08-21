using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailParticle : MonoBehaviour
{
    ParticleSystem PS;
    public ParticleSystem Back;
    private bool playing = false;
    // Start is called before the first frame update
    void Start()
    {
        PS = gameObject.GetComponent<ParticleSystem>();
        PS.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (Game_Controller.GameStarted == false)
        {
            PS.Pause();
            playing = false;

            return;
        }

        if (playing == false)
        {
            playing = true;
            PS.Play();

        }

        var main = PS.main;
        var speedMod = PS.velocityOverLifetime;
        main.startRotation = transform.parent.transform.rotation.eulerAngles.z * -1 * Mathf.Deg2Rad;
        speedMod.speedModifier = (Game_Controller.MainSpeed / 1000f) * Time.deltaTime * 40f;

        var backSpeedMod = Back.velocityOverLifetime;
        backSpeedMod.speedModifier = (Game_Controller.MainSpeed / 1000f) * Time.deltaTime * 40f;

    }
}
