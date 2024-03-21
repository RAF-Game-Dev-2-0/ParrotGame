using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeleeAnimationAttack : AttackPlayer
{

    [SerializeField] GameObject attackBox;
    [SerializeField] float attackDuration;
    private BoxCollider hitBox;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        if(!attackBox){
            Debug.Log("attackBox GameObject not attached (Enemy/MeleeAnimationAttack)");
            return;
        }
        else if(!(hitBox = attackBox.GetComponent<BoxCollider>()))
            Debug.Log("missing BoxCollider in" + attackBox.name);
        
        hitBox.enabled = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (agent.remainingDistance <= range)
        //{
        //    agent.isStopped = true;
        //}
    }

    public override void Attack(Transform playerTransform){
        StartAttack();
        Invoke("EndAttack", attackDuration);
        this.playerTransform = playerTransform;
    }
    
    private void StartAttack(){
        hitBox.enabled = true;
        attackFinished = false;
        agent.isStopped = true;
    }

    //private void OnTriggerEnter(Collider coll){
        
    //    if(coll.gameObject.tag == "Player"){
    //        //Damage player
    //        Debug.Log("DamagePlayer");
    //    }

    //}

    private void EndAttack(){
        hitBox.enabled = false;
        attackFinished = true;
        agent.isStopped = false;
    }
}
