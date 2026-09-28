using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Pawn : MonoBehaviour
{
  
    
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public abstract void Start();

    // Update is called once per frame
    public abstract void Update();



    public abstract void Teleport();


    //Normal Speed Variant Here
    public abstract void MakeDecsisions();

    public abstract void MoveForwardLocal();

    public abstract void MoveBackwardLocal();

    public abstract void RotateClockwise();

    public abstract void RotateCounterClock();

    //Turbo Speed Variant Here
    public abstract void MoveForwardLocalTurbo();

    public abstract void MoveBackwardLocalTurbo();

    public abstract void RotateClockTurbo();

    public abstract void RotateCounterClockTurbo();

    // World Variant
    public abstract void MoveForwardWorld();

    public abstract void MoveBackwardWorld();

    public abstract void MoveLeftWorld();

    public abstract void MoveRightWorld();

   
       
    
}

