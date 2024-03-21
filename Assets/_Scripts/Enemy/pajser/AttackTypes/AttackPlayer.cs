using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackPlayer : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public float range = 0.5f;
    public bool attackFinished;

    void Awake(){
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    public abstract void Attack(Transform playerTransform);

}
