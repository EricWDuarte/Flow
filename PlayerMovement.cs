using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform midpos;
    Rigidbody2D rb;

    AudioSource audioSource;
    public AudioClip playerSound;

    bool inverted = false;
    private float drag = 0.25f;
    private float angDrag = 20f;
    private float throwForce = -50f;

    float midTrendVel = 5f;
    float horizontalControlVel = 40f;


    public GameObject loseScreen;

    float maxVel = 8f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0, 600f));
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Game_Controller.GameStarted && Input.anyKeyDown)
        {
            rb.gravityScale = -rb.gravityScale;
            rb.AddTorque(Random.Range(70f, 80f) * rb.gravityScale);
            //gameObject.transform.localScale = new Vector3(1.5f, rb.gravityScale * 1.5f, 1.5f);
            rb.AddForce(new Vector2(0, 900f * -rb.gravityScale));
            audioSource.pitch = Random.Range(0.99f, 1.01f);
            audioSource.PlayOneShot(playerSound);
        }
    }

    private void FixedUpdate()
    {
        if (Game_Controller.GameStarted == false)
        {
            return;
        }


            Vector2 temp = rb.velocity;


            if (transform.position.x < -0.5)
            {
                temp.x += 0.15f;
            }
            if (transform.position.x > 0.5)
            {
                temp.x -= 0.15f;
            }

            if (temp.x > maxVel)
            {
                temp.x = maxVel;
            }
            if (temp.x < -maxVel)
            {
                temp.x = -maxVel;
            }

            if (transform.position.x > -1.5f && transform.position.x < 1.5f)
            {
                temp.x *= 0.90f;
                if (temp.x < 0.005f && temp.x > -0.005f)
                {
                    temp.x = 0;
                }
            }

            rb.velocity = temp;
            rb.angularVelocity = Mathf.MoveTowards(rb.angularVelocity, 0, angDrag);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (Game_Controller.GameStarted == false)
        {
            return;
        }

        if (collision.tag == "Block")
        {
            rb.AddForce(new Vector2(throwForce, 0));
            Game_Controller.MainSpeed *= 0.993f;
            collision.gameObject.SendMessage("Touched");
            OverSlowerSFX.volume += 0.02f;
            OverSlowerSFX.volume *= 1.1f;
        }

        if (collision.tag == "Lose")
        {
            loseScreen.SetActive(true);
            Game_Controller.died = true;
        }

        if (collision.tag == "Booster")
        {
            rb.AddForce(new Vector2(-throwForce/2, 0));
            Game_Controller.MainSpeed += 4f;
            OverBoosterSFX.volume += 0.02f;
            OverBoosterSFX.volume *= 1.1f;
        }
        }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (Game_Controller.GameStarted == false)
        {
            return;
        }

        if (collision.transform.tag == "Ground")
        {
            WallHitSFX.instance.Hit(rb.velocity.magnitude);
        }
    }
}
