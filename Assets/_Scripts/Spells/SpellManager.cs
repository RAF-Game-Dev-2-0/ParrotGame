using UnityEngine;
using System.Collections.Generic;
using System;

public class SpellManager : MonoBehaviour
{
    private Player playerScript;

    private Spell.SpellType primarySpellType;
    private Spell.SpellConnector connector;
    private Spell.SpellType secondarySpellType;
    private SpellHolder holder;
    private Dictionary<string, Spell> spellDictionary;

    [SerializeField] private float actionLock = 0.100f;
    private float lastAction = 0;

    void Awake()
    {
        holder = GetComponent<SpellHolder>();
        playerScript = GetComponent<Player>();
        spellDictionary = new Dictionary<string, Spell>();
        ResetSpellState();
    }

    private void Start()
    {
        QualitySettings.antiAliasing = 2;
        // Na primer: "Fire_And_Air"
        Spell[] allSpells = Resources.LoadAll<Spell>("Spells"); 
        foreach (Spell spell in allSpells)
        {
            string key = spell.spellType.ToString();
            if (spell.connector != Spell.SpellConnector.None)
            {
                key += "_" + spell.connector.ToString() + "_" + spell.secondarySpellType.ToString();
            }
            spellDictionary.Add(key, spell);
        }
    }

    private bool CheckAction()
    {
        if (lastAction + actionLock < Time.time)
        {
            lastAction = Time.time;
            return true;
        }
        return false;
    }

    public void SetSpellType(Spell.SpellType spellType)
    {
        if (!CheckAction()) return;
        if (connector != Spell.SpellConnector.None ) secondarySpellType = spellType;
        else primarySpellType = spellType;
    }
    public void SetConnectorType(Spell.SpellConnector spellConnector)
    {
        if (!CheckAction()) return;
        if (primarySpellType == Spell.SpellType.None) return;
        if (secondarySpellType != Spell.SpellType.None) return;
        connector = spellConnector;
    }

    public void CraftSpell()
    {
        if (!CheckAction()) return;
        if (primarySpellType == Spell.SpellType.None) return;
        string key = primarySpellType.ToString();
        if (connector != Spell.SpellConnector.None)
        {
            if(secondarySpellType == Spell.SpellType.None) return;
            key += "_" + connector.ToString() + "_" + secondarySpellType.ToString();
        }
        if (spellDictionary.TryGetValue(key, out Spell combinedSpell))
        {
            holder.spell = combinedSpell;
        }
        else
        {
            holder.spell = null;
        }
        Debug.Log(primarySpellType);
        Debug.Log(connector);
        Debug.Log(secondarySpellType);
        ResetSpellState();

        Invoke(nameof(CastSpell), 1);
    }
    public void CancelSpell()
    {
        if (!CheckAction()) return;
        ResetSpellState();
    }
    private void ResetSpellState()
    {
        primarySpellType = Spell.SpellType.None;
        connector = Spell.SpellConnector.None;
        secondarySpellType = Spell.SpellType.None;
    }
    public void CastSpell()
    {
        if (!CheckAction()) return;
        if (holder.spell == null) throw new System.Exception("Spell type missing.");
        Debug.Log("Casting : " + holder.spell.name);
        holder.spell.Cast(this);
    }

}
