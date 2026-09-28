    using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Controller
{
    public KeyCode TeleportKey;
   
    //[W] Key For moving Foward 
    public KeyCode MoveForwardLocal;
    //[S] key For moving Backward
    public KeyCode MoveBackwardLocal;
    //[D] Key For Rotating ClockWise 
    public KeyCode RotateClockwise;
    //[A] Key For Rotating Counter-Clockwise
    public KeyCode RotateCounterClock;

    //World Space Movement 

    //[Up] Arrow
    public KeyCode MoveForwardWorld;
    //[Down] Arrow
    public KeyCode MoveBackwardWorld;
    //[Left] Arrow
    public KeyCode MoveLeftWorld;
    //[Right] Arrow
    public KeyCode MoveRightWorld;


    //Speed Change

    //Left Shift Button
    public KeyCode TurboSpeedL;
    //Right Shift Button

    public KeyCode TurboSpeedR;

    public override void MakeDecisions()
    {
        if (Input.GetKey(TurboSpeedL) || Input.GetKey(TurboSpeedR))
        {
            //Faster Version method are used here 

            if (Input.GetKey(MoveForwardLocal))
            {
                //
                pawn.MoveForwardLocalTurbo();
            }
            if (Input.GetKey(MoveBackwardLocal))
            {
                //
                pawn.MoveBackwardLocalTurbo();
            }
            if (Input.GetKey(RotateCounterClock))
            {
                //
                pawn.RotateCounterClockTurbo();
            }
            if (Input.GetKey(RotateClockwise))
            {
                //
                pawn.RotateClockTurbo();
            }
        }

        else
        {
            //Normal Version method used here
            if (Input.GetKey(MoveForwardLocal))
            {
                //Foward
                pawn.MoveForwardLocal();
            }
            if (Input.GetKey(MoveBackwardLocal))
            {
                //Backward
                pawn.MoveBackwardLocal();
            }
            if (Input.GetKey(RotateClockwise))
            {
                //Clockwise
                pawn.RotateClockwise();
            }
            if (Input.GetKey(RotateCounterClock))
            {
                //CounterClockwise
                pawn.RotateCounterClock();

            }

        }


        //World Space Key Presses 

        if (Input.GetKeyDown(MoveForwardWorld))
        {
            //
            pawn.MoveForwardWorld();
        }
        if (Input.GetKeyDown(MoveBackwardWorld))
        {
            //
            pawn.MoveBackwardWorld();
        }
        if (Input.GetKeyDown(MoveRightWorld))
        {
            //
            pawn.MoveRightWorld();
        }
        if (Input.GetKeyDown(MoveLeftWorld))
        {
            //
            pawn.MoveLeftWorld();
        }

        //Teleport Key Pressed
        if (Input.GetKeyDown(TeleportKey))
        {
            pawn.Teleport();
        }
    }
        
    

    public override void Start()
    {
        
    }

    public override void Update()
    {
        MakeDecisions();
    }

   
}
