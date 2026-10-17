using UnityEngine;

public class ShooterBullet : Shooter
{
    public Transform bulletSpawnPoint;

    public GameObject bulletPrefab;


    public override void Shoot()
    {
        if (bulletSpawnPoint != null && bulletPrefab != null)
        {
            
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            // Plays the gun sound through the GameManager's SFX player

            GameManager.instance.sfxPlayer.PlayOneShot(GameManager.instance.fireGunSound);
        }
    }
    
    public override void Start()
    {
        
    }
    public override void Update()
    {
        
    }
}