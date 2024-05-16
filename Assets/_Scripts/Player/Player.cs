using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class Player : MonoBehaviour, IDamagable
{
    [Header("Health attributes")] // ----------------------------
    public float maxHealth;
    public float health {get; set;}
    [HideInInspector] public bool playerIsDead;
    // ---------------------------------------------------------
    [SerializeField] GameObject playerAbility;
    [SerializeField] Transform playerModel;
    // script references ----------------------------------------
    //private PlayerFeedback playerFeedback;
    [SerializeField] private Healthbar hpBarScript;
    [SerializeField] public PlayerMovement playerMovement;


    private void Start()
    {
        // maxHealth = maxHpInInspector;

        health = maxHealth; 
        playerIsDead = false;
    }

    private void Update()
    {
        
    }

    // ------------------------------------------------------------- Hp Stuff

    public void TakeDamage(float damage, Transform source){
        if(playerIsDead)
            return;
        
        health -= damage;
        hpBarScript.UpdateHealthbar(health, maxHealth);
        if(health < 0){
            health = 0;
            Die();
        }
        
    }

    public void Heal(float amount)
    {

    }

    private void Die()
    {
        // Death animation
        hpBarScript.gameObject.SetActive(false);
    }

    // -----------------------------------------------------------------
    public void FireAbility(){
        Instantiate(playerAbility, transform.position, playerModel.rotation);
    }


}
