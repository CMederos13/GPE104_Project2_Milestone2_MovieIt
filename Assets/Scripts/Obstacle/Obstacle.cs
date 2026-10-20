using UnityEngine;


public class Obstacle : MonoBehaviour
{
   
    void Awake()
    {
        GameManager.instance.obstacleList.Add(this);

        //Get this Asteroid's Audio Source and start It's 3D Hum
        AudioSource humSource = GetComponent<AudioSource>();
        if(humSource != null)
        {
            humSource.clip = GameManager.instance.asteroidHumSound;
            humSource.Play();
        }
    }
    void OnDestroy()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.obstacleList.Remove(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
    