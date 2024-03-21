using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZvezdaAttack : AttackPlayer
{

    [SerializeField] List<Transform> spawnAbilityPositions;
    [SerializeField] float repeatCastAfter;
    [SerializeField] GameObject abilityObject;
    bool attacking;
    
    void Start(){
        attacking = false;
    }

    public override void Attack(Transform playerTransform){
        if(!attacking)
            InvokeRepeating("CastAbility", 0, repeatCastAfter);
    }

    private void CastAbility(){
        // Animation
        attacking = true;
        foreach(Transform point in spawnAbilityPositions){
            Instantiate(abilityObject, point.position, point.rotation);
        }
    }


    


}
