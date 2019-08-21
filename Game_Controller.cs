using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Controller : MonoBehaviour
{

    public static float MainSpeed = 1000f;
    public static bool died = false;
    private float diedDelay = 0.5f;
    public static bool GameStarted = false;
    public float acc = 0.5f;

    public GameObject startScreen;
    public Text speedText;
    public Text highscoreText;

    public static Game_Controller instance;
    // Start is called before the first frame update
    void Start()
    {
        died = false;
        instance = this;
        MainSpeed = 1000f;
        GameStarted = false;
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (died)
        {
            diedDelay -= Time.deltaTime;
        }

        if (died && diedDelay < 0 && Input.anyKeyDown)
        {
            Restart();
        }

        if (GameStarted == false && Input.anyKeyDown)
        {
            GameStarted = true;
            Time.timeScale = 1;
            startScreen.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            GameStarted = false;
            Time.timeScale = 0;
            startScreen.SetActive(true);
        }

        if (GameStarted && died == false) {
            MainSpeed += acc * Time.deltaTime * 40f;
        }

        if (MainSpeed > MasterStaticVariables.Highscore)
        {
            MasterStaticVariables.Highscore = Mathf.CeilToInt(MainSpeed);
        }

        AudioListener.pause = !MasterStaticVariables.sound;

        highscoreText.text = "BEST:" + MasterStaticVariables.Highscore;
        speedText.text = Mathf.CeilToInt(MainSpeed).ToString();
    }

    public void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
