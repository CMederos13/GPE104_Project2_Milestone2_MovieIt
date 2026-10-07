using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float fireForce;

    private Rigidbody2D rb;

    private Transform tf;

    public float lifetime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        tf = GetComponent<Transform>();

        if (rb != null && tf != null)
        {
            rb.AddForce(tf.up * fireForce);
        }

        Destroy(gameObject, lifetime);
    
        
    }
                
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
