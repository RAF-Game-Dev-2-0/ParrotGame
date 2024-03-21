using UnityEngine;

public class EnemyPatrolState : EnemyBaseState
{


    public override void EnterState(EnemyStateManager enemy){
        enemy.agent.SetDestination(enemy.GetNextDestination());
    }
    public override void UpdateState(EnemyStateManager enemy){
        if(enemy.agent.remainingDistance <= enemy.agent.stoppingDistance){
            enemy.SwitchState(enemy.IdleState);
        }
    }
    public override void OnTriggerEnter(EnemyStateManager enemy){

    }
    public override void OnTriggerExit(EnemyStateManager enemy){

    }

    
}
