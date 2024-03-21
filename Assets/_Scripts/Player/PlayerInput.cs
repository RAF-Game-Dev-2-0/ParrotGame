using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    private SpellManager spellManager;

    [Header("KeyBinds")]
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
        spellManager = GetComponent<SpellManager>();
    }

    
    void Update(){
        HandleSpellInput();
    }

    private void HandleSpellInput()
    {
        if (Input.GetKeyDown(fireSpellKeyCode))
        {
            Debug.Log("Set Fire");
            spellManager.SetSpellType(Spell.SpellType.Fire);
        }
        else if (Input.GetKeyDown(airSpellKeyCode))
        {
            Debug.Log("Set Air");
            spellManager.SetSpellType(Spell.SpellType.Air);
        }
        else if (Input.GetKeyDown(earthSpellKeyCode))
        {
            Debug.Log("Set Earth");
            spellManager.SetSpellType(Spell.SpellType.Earth);
        }
        else if (Input.GetKeyDown(waterSpellKeyCode))
        {
            Debug.Log("Set Water");
            spellManager.SetSpellType(Spell.SpellType.Water);
        }
        else if (Input.GetKeyDown(andConnectorKeyCode))
        {
            Debug.Log("Set And");
            spellManager.SetConnectorType(Spell.SpellConnector.And);
        }
        else if (Input.GetKeyDown(thenConnectorKeyCode))
        {
            Debug.Log("Set Then");
            spellManager.SetConnectorType(Spell.SpellConnector.Then);
        }
        else if (Input.GetKeyDown(launchSpellKeyCode))
        {
            Debug.Log("Set Launch");
            spellManager.CraftSpell();
        }
        else if (Input.GetKeyDown(cancelSpellKeyCode))
        {
            Debug.Log("Set Cancel");
            spellManager.CancelSpell();
        }

    }

}