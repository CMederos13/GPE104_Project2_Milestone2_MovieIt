using UnityEngine;

public class DeathPawn : Death
{

    private Controller controller;
    public override void Die()
    {
        // Play the explosion sound through the GameManager's SFX player
        GameManager.instance.sfxPlayer.PlayOneShot(GameManager.instance.deathSound);

        
        //Hands over Listening priority to the camera so sounds can still be heard after destroyed
        AudioListener shipListener = GetComponent<AudioListener>();
        
        if (shipListener != null)
        {
            shipListener.enabled = false;
        }

        GameManager.instance.cameraListener.enabled = true; 

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

   