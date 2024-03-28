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

    public float power;
    public float range;
    public float castTime;
    public GameObject spellObject;
    public MonoBehaviour controller;

    public void Cast(SpellManager parent)
    {
        Instantiate(spellObject, parent.transform.position, Quaternion.identity);
    }

}
