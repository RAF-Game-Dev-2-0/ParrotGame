using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class StateMachine<EState> : MonoBehaviour where EState : Enum
{
    protected Dictionary<EState, BaseState<EState>> States = new Dictionary<EState, BaseState<EState>>();

    protected BaseState<EState> CurrentState;

    

    void Start(){
        CurrentState.EnterState();
    }

    void Update(){
        EState nextStateKey = CurrentState.GetNextState();

        if(nextStateKey.Equals(CurrentState.StateKey)){
            CurrentState.UpdateState();
        } else {
            TransitionToState(nextStateKey);
        }


        CurrentState.UpdateState();
    }

    public void TransitionToState(EState stateKey){
        CurrentState.ExitState();
        CurrentState = States[stateKey];
        CurrentState.EnterState();
    }

    void OnTriggerEnter(Collider coll){
        CurrentState.OnTriggerEnter(coll);
    }

    void OnTriggerStay(Collider coll){
        CurrentState.OnTriggerStay(coll);
    }

    void OnTriggerExit(Collider coll){
        CurrentState.OnTriggerExit(coll);
    }
}
