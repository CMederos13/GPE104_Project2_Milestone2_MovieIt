using UnityEngine;
using UnityEngine.InputSystem;

public class Teleport : MonoBehaviour
{
    public KeyCode TeleportKey;


    //Setting the Min-Max of X and Y axis
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public Transform tf;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(TeleportKey))
        {
            tf.position = new Vector3(Random.Range(minX, maxX), (Random.Range(minY, maxY)));
        }
    }
}
