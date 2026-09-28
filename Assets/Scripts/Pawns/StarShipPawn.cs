using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class StarShipPawn : Pawn
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public Transform tf;

    public float worldSpeed = 2f;

    public float normalSpeed;
    public float turboSpeed;

    public float normalRotateSpeed;
    public float turboRotateSpeed;
    public override void MakeDecsisions()
    {
        throw new System.NotImplementedException();
    }

    public override void MoveForwardLocal()
    {
        tf.position = tf.position + tf.up * normalSpeed * Time.deltaTime;
    }

    public override void MoveBackwardLocal()
    {
        tf.position = tf.position + tf.up * -normalSpeed * Time.deltaTime;
    }

    public override void RotateClockwise()
    {
        tf.Rotate(0,0,normalRotateSpeed * -Time.deltaTime);
    }

    public override void RotateCounterClock()
    {
        tf.Rotate(0, 0, normalRotateSpeed * Time.deltaTime);
    }
    //World Section
    public override void MoveForwardWorld()
    {
        tf.position = tf.position + Vector3.up;
    }

    public override void MoveLeftWorld()
    {
        tf.position = tf.position + -Vector3.right;
    }

    public override void MoveRightWorld()
    {
        tf.position = tf.position + Vector3.right; 
    }
    public override void MoveBackwardWorld()
    {
        tf.position = tf.position + -Vector3.up;
    }

    //Turbo Section
    public override void RotateClockTurbo()
    {
        tf.Rotate(0, 0, turboRotateSpeed * -Time.deltaTime);
    }

    public override void RotateCounterClockTurbo()
    {
        tf.Rotate(0, 0, turboRotateSpeed * Time.deltaTime);
    }

    public override void MoveForwardLocalTurbo()
    {
        tf.position = tf.position + tf.up * turboSpeed * Time.deltaTime;
    }

    public override void MoveBackwardLocalTurbo()
    {
        tf.position = tf.position + tf.up * -turboSpeed * Time.deltaTime;
    }

    
    public override void Teleport()
    {
        tf.position = new Vector3(Random.Range(minX,maxX), Random.Range(minY, maxY));
    }
    
   

    public override void Start()
    {
        tf = GetComponent<Transform>();
    }

    public override void Update()
    {

    }
}