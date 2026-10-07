using UnityEngine;

public class Obstacle : MonoBehaviour
{
   
    void Start()
    {
        GameManager.instance.obstacleList.Add(this);
               
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
    