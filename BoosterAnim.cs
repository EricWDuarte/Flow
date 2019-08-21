using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterAnim : MonoBehaviour
{
    Renderer sr;
    Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        offset.x += 0.04f;
        sr.material.mainTextureOffset = offset;
    }
}
