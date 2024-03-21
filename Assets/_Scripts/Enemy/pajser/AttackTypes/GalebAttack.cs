using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalebAttack : AttackPlayer
{

    public Transform player;
    [SerializeField] BoxCollider weaponTrigger;
    [SerializeField] private float maxAttackSpeed = 23f;
    private float startSpeed;
    private bool accelerating;
    Vector3 prevHorizDirection;
    Vector3 horizontalDirection;
    Vector3 directionToPlayer;
    Vector3 playerStartPos;


    // Start is called before the first frame update
    void Start()
    {
        attackFinished = true;
        accelerating = true;
        startSpeed = agent.speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!attackFinished){
            Vector3 directionToPlayer = playerStartPos - transform.position;
            Vector3 horizontalDirection = new Vector3(directionToPlayer.x, 0f, directionToPlayer.z);

            // Check if accelerating or decelerating based on the distance to the playerStartPos
            if (accelerating){
                // agent.speed = Mathf.Lerp(agent.speed, maxAttackSpeed, (range - horizontalDirection.magnitude) / range);
                agent.speed = maxAttackSpeed;

                if(prevHorizDirection.magnitude < horizontalDirection.magnitude)
                    accelerating = false;

                prevHorizDirection = horizontalDirection;
            }
            else{ // Decelerating
                agent.speed = Mathf.Lerp(agent.speed, startSpeed, (range - agent.remainingDistance) / range - 0.3f); // -------------------nzm sto nece da radi bez 0.3 lepo
                // agent.speed = startSpeed;
                Debug.Log((range - agent.remainingDistance) / range);

                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    attackFinished = true;
                    weaponTrigger.enabled = false;
                }
            }
        }
    }

    public override void Attack(Transform playerTransform){
        attackFinished = false;
        playerStartPos = playerTransform.position;
        Vector3 directionOfAttack = (playerTransform.position - transform.position);
        agent.SetDestination(playerTransform.position + directionOfAttack);
        weaponTrigger.enabled = true;

        prevHorizDirection = new Vector3(100, 100, 100);
        accelerating = true;
        player = playerTransform; // dont need it for now
    }
}
