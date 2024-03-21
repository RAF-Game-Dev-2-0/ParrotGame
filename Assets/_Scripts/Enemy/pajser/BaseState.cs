using System;
using UnityEngine;

public abstract class BaseState<EState> where EState : Enum
{
    public BaseState(EState key){
        StateKey = key;
    }

    public EState StateKey{ get; set; } 

    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
    public abstract EState GetNextState();
    public virtual void OnTriggerEnter(Collider coll){}
    public virtual void OnTriggerStay(Collider coll){}
    public virtual void OnTriggerExit(Collider coll){}
}
