using UnityEngine;

public class Obstacle : MonoBehaviour
{
   
    void Start()
    {
        GameManager.instance.obstacleList.Add(this);
               
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
    