using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    private Death death;

    public Image healthBar;

    public GameObject damageNumberPrefab;

    public Transform damageNumberParent; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        death = GetComponent<Death>();

        if(healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damageAmount)
    {
        //If I'm already dead,Ignore any more damage
        //This ends the method right there and skips everything below it; ex. a dead asteroid hit by a second bullet in the same frame
        if (currentHealth <= 0)
        {
            return;
        }
    
        // subtract damage from my current health

        currentHealth -= damageAmount;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Plays the damage sound through the GameManager's SFX Player
        GameManager.instance.sfxPlayer.PlayOneShot(GameManager.instance.takingDamageSound);

        //shows the floating damage number
        
        SpawnDamageNumber(damageAmount);

        //healthBar
        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }
        //Death 
        if (currentHealth <= 0)
        {
            if (death != null)
            {
                death.Die();
            }

        }
        
    }
    private void SpawnDamageNumber(float amount)
    {

       
        if (damageNumberPrefab == null)
        {
            return;
        }

        GameObject newNumber; 
        if (damageNumberParent != null)
        {
            // spawns inside the HUD Health Bar, Position by the anchor
            newNumber = Instantiate(damageNumberPrefab, damageNumberParent);
        }
        else
        {
            // spawns at the object's position, a little above it
            newNumber = Instantiate(damageNumberPrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);
        }

        //had to look this up in the unity manual along with reddit
        // also used lecture 6.2 
        // Takes the new number how much damage to display 

        DamageGhostNumbers numberscript = newNumber.GetComponent<DamageGhostNumbers>();
        if(numberscript != null)
        {
            numberscript.SetDamage(amount);
        }
    }
    public void Heal(float healAmount)
    {
        // Healing Message
        Debug.Log("Patching up!");
       // Adding Health to Current Health
        
        currentHealth += healAmount;

        // if health > max then set health to max
        //if (currentHealth > maxHealth)
        // {
        //   currentHealth = maxHealth;
        // setting the max health for healing 
        
        currentHealth = Mathf.Clamp(currentHealth, 0 , maxHealth);


        // if health > max then set health to max
        //if (currentHealth > maxHealth)
        // {
        //   currentHealth = maxHealth;
        //}
        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }

       
    }

   
    public void Die()
    { 
            Debug.Log("Wasted!");
    }
}


//TO DO LIST 
//  TODO: Create Ghost health script 
//  TODO: Finish Video for milestone 4
//  TODO: Write sound script 
//  TODO: 
//  TODO:  
//  TODO: 
//  TODO: 
//  TODO: 
//  TODO: 
//  TODO: 
//  TODO: 
//  TODO: 
//  TODO: 

//
//
