using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    
    float tempIdleTime;

    public override void EnterState(EnemyStateManager enemy){
        tempIdleTime = enemy.doIdleTime;
        // do idle animation
            // Debug.Log("idlee:");
    }
    public override void UpdateState(EnemyStateManager enemy){

        if(tempIdleTime > 0){
            tempIdleTime -= Time.deltaTime;
        }
        else{
            enemy.SwitchState(enemy.PatrolState);
        }
    }
    public override void OnTriggerEnter(EnemyStateManager enemy){
        
    }
    
    public override void OnTriggerExit(EnemyStateManager enemy){
        
    }
}
