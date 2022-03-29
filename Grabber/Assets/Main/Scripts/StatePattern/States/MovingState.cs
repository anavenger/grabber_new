using System.Collections;
using System.Collections.Generic;
using TTP.Controllers;
using UnityEngine;
using TTP.State;
public class MovingState : State
{
    private bool isMoving;
    private bool buttonClicked;

    public MovingState(Grabber grabber, StateMachine stateMachine) : base(grabber, stateMachine)
    { 
    }

    public override void HandleInput()
    {
        base.HandleInput();
        isMoving = InputUtils.DetectMoving();
        buttonClicked = InputUtils.DetectButtonClick();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!isMoving)
            _stateMachine.ChangeState(_grabber.StandingState);
        else if (buttonClicked)
        {
            _stateMachine.ChangeState(_grabber.GoingDownState);
        }
    }
    
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        _joystick.Move();
        _grabber.Move();
    }
    
    public override void Exit()
    {
        _joystick.MoveToIdle();
    }
}

