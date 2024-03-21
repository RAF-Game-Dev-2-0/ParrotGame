using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerWalkState<EState> : BaseState<EState> where EState : Enum
{
     

    public PlayerWalkState(EState enumState) : base(enumState)
    {
        
    }

    public override void EnterState(){
        Debug.Log("enter PlayerWalk");
    }

    public override void ExitState(){
        Debug.Log("exit PlayerWalk");
    }

    public override void UpdateState(){

    }

    public override EState GetNextState(){
        return StateKey;
    }

}
