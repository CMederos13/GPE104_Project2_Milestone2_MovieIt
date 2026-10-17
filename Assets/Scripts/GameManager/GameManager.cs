using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerController playerController;
    public List<Obstacle> obstacleList;

    public int score;

    public TMP_Text text;

    public AudioClip fireGunSound;

    public AudioClip teleportSound;

    public AudioClip gameOverSound;

    public AudioClip backgroundMusic;

    public AudioClip takingDamageSound;

    public AudioClip asteroidHumSound;

    public AudioSource sfxPlayer;

    public AudioSource musicPlayer;
    
        
    
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
    }
    void Update()
    {
    
        if (obstacleList != null)
        {
            if (obstacleList.Count <= 0 && playerController != null)
            {
                if (playerController.pawn != null)
                {
                    Debug.Log("Victory!");
                }
                
            }
        }
        if (playerController != null)
        {
            if (playerController.pawn == null)
            {
                Debug.Log("Mission Failure!");
            }

        }

        if (text != null)
        {
            text.text = "" + score;
        }
            
    }
}
