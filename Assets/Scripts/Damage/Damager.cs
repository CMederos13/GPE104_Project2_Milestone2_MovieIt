using Unity.VisualScripting;
using UnityEngine;

public class Damage : MonoBehaviour
{

    public float damageAmount;

    public bool isInstaKill;

    private Health OtherHealthComponent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OtherHealthComponent = collision.GetComponent<Health>();
        
        if (OtherHealthComponent != null)
        {
            if (isInstaKill)
            {
                OtherHealthComponent.TakeDamage(OtherHealthComponent.maxHealth);
            }
            else
            {
                OtherHealthComponent.TakeDamage(damageAmount);
            }
            Destroy(gameObject);

        } 
    
    }





}



