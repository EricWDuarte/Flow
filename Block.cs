using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;

    float speed = 1000f;
    public float speedMult = 1f;
    float speedRand;
    // Start is called before the first frame update
    void Start()
    {
        speed = Game_Controller.MainSpeed;
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        speedRand =  Random.Range(0.6f, 1.4f);
        Destroy(gameObject, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Game_Controller.GameStarted == false)
        {
            return;
        }
        speed = Game_Controller.MainSpeed;

        rb.velocity = new Vector2(-speed * speedMult * speedRand * Time.deltaTime, 0);
    }

    public void Touched()
    {
        Color color = sr.color;

        color.a += 0.05f;
        color.r -= 0.02f;
        color.g -= 0.05f;
        color.b -= 0.05f;

        sr.color = color;
    }

}
