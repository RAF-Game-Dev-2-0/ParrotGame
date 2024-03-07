using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    private Player playerScript;
    private SpellManager spellManager;

    [SerializeField] public KeyCode fireSpellKeyCode = KeyCode.Alpha1;
    [SerializeField] public KeyCode airSpellKeyCode = KeyCode.Alpha2;
    [SerializeField] public KeyCode earthSpellKeyCode = KeyCode.Alpha3;
    [SerializeField] public KeyCode waterSpellKeyCode = KeyCode.Alpha4;
    [SerializeField] public KeyCode andConnectorKeyCode = KeyCode.Q;
    [SerializeField] public KeyCode thenConnectorKeyCode = KeyCode.E;
    [SerializeField] public KeyCode launchSpellKeyCode = KeyCode.Mouse0;
    [SerializeField] public KeyCode cancelSpellKeyCode = KeyCode.Mouse1;

    void Awake()
    {
        playerScript = GetComponent<Player>();
        spellManager = GetComponent<SpellManager>();
    }

    
    void Update(){
        HandleSpellInput();
    }

    private void HandleSpellInput()
    {
        Debug.Log("Hello spell input");
        if (Input.GetKeyDown(fireSpellKeyCode))
        {
            spellManager.SetSpellType(Spell.SpellType.Fire);
        }
        if (Input.GetKeyDown(airSpellKeyCode))
        {
            spellManager.SetSpellType(Spell.SpellType.Air);
        }
        if (Input.GetKeyDown(earthSpellKeyCode))
        {
            spellManager.SetSpellType(Spell.SpellType.Earth);
        }
        if (Input.GetKeyDown(waterSpellKeyCode))
        {
            spellManager.SetSpellType(Spell.SpellType.Water);
        }
        if (Input.GetKeyDown(andConnectorKeyCode))
        {
            spellManager.SetConnectorType(Spell.SpellConnector.And);
        }
        if (Input.GetKeyDown(thenConnectorKeyCode))
        {
            spellManager.SetConnectorType(Spell.SpellConnector.Then);
        }
        if (Input.GetKeyDown(launchSpellKeyCode))
        {
            spellManager.CraftSpell();
        }
        if (Input.GetKeyDown(cancelSpellKeyCode))
        {
            spellManager.CancelSpell();
        }

    }

    public Vector2 GetMovementVectorNormalized(){
        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W)){
            inputVector.y = +1;  
        } if (Input.GetKey(KeyCode.S)) {
            inputVector.y = -1;
        } if (Input.GetKey(KeyCode.A)) {
            inputVector.x = -1;
        } if (Input.GetKey(KeyCode.D)) {
            inputVector.x = +1;
        }

        inputVector = inputVector.normalized;
        return inputVector;
    }

}