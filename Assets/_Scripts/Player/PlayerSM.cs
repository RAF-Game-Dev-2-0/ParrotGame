using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Testiramo
{


public class PlayerSM : StateMachine<PlayerSM.EPlayerStates>
{
    public enum EPlayerStates{
        Idle,
        Walk,
        Run,
        Attack
    }

    void Awake()
    {
        
        InitializeStates();
    }

    private void InitializeStates(){
        States.Add(EPlayerStates.Idle, new PlayerIdleState<EPlayerStates>(EPlayerStates.Idle));
        States.Add(EPlayerStates.Walk, new PlayerWalkState<EPlayerStates>(EPlayerStates.Walk));
        States.Add(EPlayerStates.Run, new PlayerRunState<EPlayerStates>(EPlayerStates.Run));
        States.Add(EPlayerStates.Attack, new PlayerAttackState<EPlayerStates>(EPlayerStates.Attack));
        CurrentState = States[EPlayerStates.Idle];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
}
