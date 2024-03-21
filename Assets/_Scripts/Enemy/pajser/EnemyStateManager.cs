using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour, IDamagable
{

    // references
    public NavMeshAgent agent;
    [HideInInspector] public AttackPlayer attackScript;
    public Healthbar HealthbarScript;

    // patroling
    [SerializeField] List<Transform> patrolPointsList;
    Queue<Vector3> patrolPoints = new Queue<Vector3>();


    // state reference
    EnemyBaseState currentState;
    public EnemyPatrolState PatrolState = new EnemyPatrolState();
    public EnemyIdleState IdleState = new EnemyIdleState();
    public EnemyAttackState AttackState = new EnemyAttackState();
    public EnemyChaseState ChaseState = new EnemyChaseState();

    // adsd
    [SerializeField] public float doIdleTime;
    [HideInInspector] public Transform playerTransform;
    

    //enemy stats
    [SerializeField] private float maxHp = 100;
    public float health {get; set;}
    public bool isDead {get; private set;}
    

    



    void Awake(){
        agent = GetComponent<NavMeshAgent>();
        attackScript = GetComponent<AttackPlayer>();
        if(patrolPointsList.Count <= 1){
            patrolPointsList.Add(transform);
            // Debug.LogWarning("No patrol points on " + this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        foreach(Transform point in patrolPointsList){ // transfer points from list<Transform> to queue<Vector3>
            patrolPoints.Enqueue(point.position);
        }
        
        health = maxHp;

        // Start state = idle
        currentState = IdleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
        
    }

    public void SwitchState(EnemyBaseState state){
        currentState = state;
        agent.isStopped = false; // this line need to be before EnterState();
        state.EnterState(this);
    }

    public Vector3 GetNextDestination(){
        Vector3 nextDestination = patrolPoints.Dequeue();

        patrolPoints.Enqueue(nextDestination);

        return nextDestination;
    }

    public void GetInfo(Transform T){ // Getting info about who entered/exited trigger box
        
        if(T.gameObject.tag == "Player"){
            playerTransform = T;
            SwitchState(ChaseState);
        }
        

    }

    public void TakeDamage(float damage, Transform source){
        if(isDead)
            return;

        health -= damage;

        if(health < 0){
            health = 0;
            Die();
        }    
        
        HealthbarScript.UpdateHealthbar(health, maxHp);
    }

    private void Die(){
        isDead = true;
        Destroy(this.gameObject);
    }

}
