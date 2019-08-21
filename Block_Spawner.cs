using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Spawner : MonoBehaviour
{
    public GameObject Block;
    public GameObject BigBlock;
    public GameObject fenceUp;
    public GameObject fenceDown;
    public GameObject Booster;

    private float fenceYPos = 9.5f;

    float spawnTime = 0.8f;
    float boosterTimer = 30f;
    float bigBlockTimer = 20f;
    float timer = 0;

    float reach = 5.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Game_Controller.GameStarted == false)
        {
            return;
        }

        timer += Time.deltaTime;
        bigBlockTimer += Time.deltaTime;
        boosterTimer -= Time.deltaTime;
        spawnTime = 1000f / Game_Controller.MainSpeed;
        if (timer > spawnTime)
        {
            int rd = Random.Range(0, 3);
            timer = 0;
            Instantiate(Block, new Vector3(transform.position.x, transform.position.y + Random.Range(-reach, reach), 0), Quaternion.identity);

            if (rd == 0)
            {
                Instantiate(Block, new Vector3(transform.position.x, transform.position.y + reach), Quaternion.identity);
            } else if (rd == 1)
            {
                Instantiate(Block, new Vector3(transform.position.x, transform.position.y - reach), Quaternion.identity);
            } else
            {
                Instantiate(Block, new Vector3(transform.position.x, transform.position.y + Random.Range(-reach, reach), 0), Quaternion.identity);
            }
        }

        if (bigBlockTimer > 20f  && Game_Controller.MainSpeed > 1500f && Random.value < 0.01f)
        {
            bigBlockTimer = 0;

            int rd = Random.Range(0, 3);
            if (rd == 0)
            {
                Instantiate(BigBlock, new Vector3(transform.position.x + 30f, transform.position.y + 4f), Quaternion.identity);
            }
            else if (rd == 1)
            {
                Instantiate(BigBlock, new Vector3(transform.position.x + 30f, transform.position.y - 4f), Quaternion.identity);
            } else
            {
                StartCoroutine(FenceIn());
            }

        }
        if (boosterTimer < 0)
        {
            boosterTimer = Random.Range(30f, 60f);
            Instantiate(Booster, new Vector3(transform.position.x + 2f, transform.position.y + Random.Range(-reach + 1.5f, reach - 1.5f), 0), Quaternion.identity);
        }

        Vector2 temp1 = fenceDown.transform.position;
        temp1.y = Mathf.MoveTowards(temp1.y, -fenceYPos, 0.02f);
        fenceDown.transform.position = temp1;
        Vector2 temp2 = fenceUp.transform.position;
        temp2.y = Mathf.MoveTowards(temp2.y, fenceYPos, 0.02f);
        fenceUp.transform.position = temp2;


    }

    IEnumerator FenceIn()
    {
        fenceYPos = 7f;

        yield return new WaitForSeconds(10f);

        bigBlockTimer = 0;
        fenceYPos = 9.5f;

    }
}
