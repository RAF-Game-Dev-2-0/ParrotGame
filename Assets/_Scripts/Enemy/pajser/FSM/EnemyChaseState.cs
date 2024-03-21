using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy){
        enemy.agent.SetDestination(enemy.playerTransform.position);
        // Debug.Log("chasee "+ enemy.playerTransform.position);
    }
    public override void UpdateState(EnemyStateManager enemy){
        if(enemy.playerTransform){
            if(enemy.agent.remainingDistance <= enemy.attackScript.range){
                // Debug.Log(" go to attackkkk!");
                enemy.SwitchState(enemy.AttackState);
            }else{
                enemy.agent.SetDestination(enemy.playerTransform.position);
            }

            
        }else{
            enemy.SwitchState(enemy.IdleState);
        }
    }
    public override void OnTriggerEnter(EnemyStateManager enemy){
        
    }
    public override void OnTriggerExit(EnemyStateManager enemy){
        
    }
}
