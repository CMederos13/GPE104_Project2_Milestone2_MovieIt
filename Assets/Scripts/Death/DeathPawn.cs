using UnityEngine;

public class DeathPawn : Death
{

    private Controller controller;
    public override void Die()
    {
        //Play the game over sound effect through GameManger'S SFX player
        GameManager.instance.sfxPlayer.PlayOneShot(GameManager.instance.gameOverSound);

        // Stops background Music in order to hear the GameOver sound stand out
        GameManager.instance.musicPlayer.Stop();
        
        //Hands over Listening priority to the camera so sounds can still be heard after destroyed
        AudioListener shipListener = GetComponent<AudioListener>();
        
        if (shipListener != null)
        {
            shipListener.enabled = false;
        }

        AudioListener cameraListener = Camera.main.GetComponent<AudioListener>();

        if (cameraListener != null)
        {
            cameraListener.enabled = true; 
        }

        if (controller != null)
        {
            controller.pawn = null;
        }
        Destroy(gameObject);
    }

    public override void Start()
    {
        controller = GetComponent<Controller>();
    }

    public override void Update()
    {

    }
}

   