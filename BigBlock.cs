using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBlock : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    float speed = 1000f;
    public float speedMult = 1f;
    // Start is called before the first frame update
    void Start()
    {
        speed = Game_Controller.MainSpeed;
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        Destroy(gameObject, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Game_Controller.GameStarted == false)
        {
            return;
        }
        rb.velocity = new Vector2(-speed * speedMult * Time.deltaTime, 0);
    }

    public void Touched ()
    {
        Color color = sr.color;
        color.a += 0.03f;
        sr.color = color;
    }
}
