using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerRunState<EState> : BaseState<EState> where EState : Enum
{
   

    public PlayerRunState(EState enumState) : base(enumState)
    {
        
    }

    public override void EnterState(){
        Debug.Log("enter PlayerRun");
    }

    public override void ExitState(){
        Debug.Log("exit PlayerRun");
    }

    public override void UpdateState(){

    }

    public override EState GetNextState(){
        return StateKey;
    }

}
