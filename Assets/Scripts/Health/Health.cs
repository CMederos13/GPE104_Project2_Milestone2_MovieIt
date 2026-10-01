using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    private Death death;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damageAmount)
    {
        // subtract damage from my current health

        currentHealth -= damageAmount;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        // if current health is less then zero
        if (currentHealth <= 0)
        {
            // tell this pawn die
            GetComponent<Death>().Die();
               // death.Die();
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
    }

   
    public void Die()
    { 
            Debug.Log("Wasted!");
    }
}


//TO DO LIST 
//  TODO: substract dammage from current health of pawn
//  TODO: if my current health is less then zero = death
//  TODO: tell this pawn to die 
//  TODO: Check for dodge
//  TODO: Check for immunity 
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
