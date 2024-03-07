using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spell")]
public class Spell : ScriptableObject
{
    public enum SpellType
    {
        Fire,
        Water,
        Air,
        Earth,
        None
    }

    public enum SpellConnector
    {
        And,
        Then,
        None
    }

    public SpellType spellType;
    public SpellConnector connector;
    public SpellType secondarySpellType; 

    public float power = 10.0f;
    public float range = 5.0f;
    public float castTime = 1.0f;
    public GameObject spellEffect;

}
