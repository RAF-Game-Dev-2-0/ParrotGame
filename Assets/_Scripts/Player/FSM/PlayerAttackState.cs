using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAttackState<EState> : BaseState<EState> where EState : Enum
{

    public PlayerAttackState(EState enumState) : base(enumState)
    {
        
    }

    public override void EnterState(){
        Debug.Log("enter PlayerAttack");
    }

    public override void ExitState(){
        Debug.Log("exit PlayerAttack");
    }

    public override void UpdateState(){

    }

    public override EState GetNextState(){
        return StateKey;
    }

}
