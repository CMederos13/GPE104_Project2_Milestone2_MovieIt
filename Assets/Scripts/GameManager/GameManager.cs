using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Gameplay")]
    public PlayerController playerController;
    public List<Obstacle> obstacleList;

    public int score;

    public TMP_Text text;

    [Header("Audio Clips")]
    public AudioClip fireGunSound;

    public AudioClip teleportSound;

    public AudioClip gameOverSound;

    public AudioClip backgroundMusic;

    public AudioClip takingDamageSound;

    public AudioClip asteroidHumSound;

    [Header("Audio Sources")]
    public AudioSource sfxPlayer;

    public AudioSource musicPlayer;

    public AudioListener cameraListener; // Used while in Menus

    [Header("Game Screens")]
    public GameObject mainMenuScreen;
    public GameObject creditsScreen;
    public GameObject settingsScreen;
    public GameObject victoryScreen;
    public GameObject gameOverScreen;


    [Header("Gameplay Screens")]
    public GameObject gameplay; // parent of ship,controller, and asteroids
    public GameObject gameplayUI; // Score and Health Bar


    // checks if win/lose while playing
    private bool isGameRunning = false;


    public void Awake()
    {
        obstacleList = new List<Obstacle>();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


    }

    void Start()
    {
        musicPlayer.clip = backgroundMusic;
        musicPlayer.Play();

        DoShowMainMenu();
    }
    void Update()
    {
        //checking for wiin/lose while game is running
        if (isGameRunning)
        {
            if (playerController != null && playerController.pawn == null)
            {
                DoShowGameOver();
            }
            else if (obstacleList.Count <= 0)
            {
                DoShowVictory();
            }

        }

        if (text != null)
        {
            text.text = "" + score;
        }
    }

    //Turns screen and gameplay off, this on what it needs when the bottons clicked
    private void HideAllScreens()
    {
        mainMenuScreen.SetActive(false);
        creditsScreen.SetActive(false);
        settingsScreen.SetActive(false);
        victoryScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        gameplay.SetActive(false);
        gameplayUI.SetActive(false);

    }
    public void DoShowMainMenu()
    {
        HideAllScreens();
        mainMenuScreen.SetActive(true);
        cameraListener.enabled = true;
        isGameRunning = false;
        Time.timeScale = 1;
    }

    public void DoShowCredits()
    {
        HideAllScreens();
        creditsScreen.SetActive(true);
    }
    public void DoShowSettings()
    {
        HideAllScreens();
        settingsScreen.SetActive(true);
    }

    public void DoStartGame()
    {
        HideAllScreens();
        gameplay.SetActive(true);
        gameplayUI.SetActive(true);
        cameraListener.enabled = false; //Ship's listener taking over
        score = 0;
        Time.timeScale = 1;
        isGameRunning = true;
    }
    public void DoShowVictory()
    {
        isGameRunning = false;
        HideAllScreens();
        victoryScreen.SetActive(true);
        cameraListener.enabled = true;
    }

    public void DoShowGameOver()
    {
        isGameRunning = false;
        HideAllScreens();
        gameOverScreen.SetActive(true);
        cameraListener.enabled = true;
    }
}

