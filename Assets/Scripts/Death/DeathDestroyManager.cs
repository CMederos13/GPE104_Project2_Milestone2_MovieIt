using UnityEngine;

public class DeathDestroyManager : Death

{
    private Obstacle ObstacleToRemoveOnDeath;

    public override void Die()
    {
        if (GameManager.instance != null)
        {
            if (GameManager.instance.obstacleList != null && ObstacleToRemoveOnDeath != null)
            {
                GameManager.instance.obstacleList.Remove(ObstacleToRemoveOnDeath);
            }
        }
        Destroy(gameObject);
    }

    public override void Start()
    {
        ObstacleToRemoveOnDeath = GetComponent<Obstacle>();
    }

    public override void Update()
    {
        
    }


}
