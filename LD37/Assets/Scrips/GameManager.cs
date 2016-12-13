using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager gm;

    [Tooltip("If not set, the player will default to the gameObject tagged as Player.")]
    public GameObject player;
    public GameObject level;

    public enum gameStates {Menu, Playing, Death, GameOver, BeatLevel };
    public gameStates gameState = gameStates.Playing;
    public LevelExit winBox;
    public int score = 0;
    public bool canBeatLevel = true;
    public GameObject menuCanvas;
    public GameObject mainCanvas;
    public Text timerDisplay;
    public GameObject gameOverCanvas;
    //public Text gameOverScoreDisplay;

    [Tooltip("Only need to set if canBeatLevel is set to true.")]
    public GameObject beatLevelCanvas;
    

    public AudioSource backgroundMusic;
    public AudioClip gameOverSFX;

    [Tooltip("Only need to set if canBeatLevel is set to true.")]
    public AudioClip beatLevelSFX;
    public float timeLeft;
    //private DateTime startTime;
    //private DateTime endTime;
    float realTimeLeft;

    void Start()
    {
        if (gm == null)
            gm = gameObject.GetComponent<GameManager>();

        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }





        // make other UI inactive
        gameOverCanvas.SetActive(false);
        mainCanvas.SetActive(false);
        menuCanvas.SetActive(true);
        gameState = gameStates.Menu;
        if (canBeatLevel)
            beatLevelCanvas.SetActive(false);
    }

    void Update()
    {
        switch (gameState)
        {
            case gameStates.Menu:

                break;
            case gameStates.Playing:
                realTimeLeft -= Time.deltaTime;
                timeLeft = (int)(realTimeLeft);
                timerDisplay.text = (int)(timeLeft / 60) + ":" + timeLeft % 60;
                if (realTimeLeft < 0.0f)
                {
                    mainCanvas.SetActive(false);
                    gameOverCanvas.SetActive(true);
                    gameState = gameStates.GameOver;
                }
                if (winBox.playerEntered)
                {
                    gameState = gameStates.BeatLevel;
                    showBeatLevel();
                }
                break;

        }
    }

    public void Restart()
    {
        gameState = GameManager.gameStates.Playing;
        timeLeft = 180;
        realTimeLeft = (float)timeLeft;

        menuCanvas.SetActive(false);
        mainCanvas.SetActive(true);
        level.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
        player.transform.position = new Vector3(4.0f, 10.0f, -4.7f);
    }

    public void showBeatLevel()
    {
        mainCanvas.SetActive(false);
        beatLevelCanvas.SetActive(true);
    }

}
