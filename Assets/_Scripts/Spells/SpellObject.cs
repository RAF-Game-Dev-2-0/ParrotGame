using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New SpellObject", menuName = "SpellObject")]
public class SpellObject : ScriptableObject
{
    [SerializeField]
    GameObject spellObjectParent;

    private void Awake()
    {
        
    }

    public void OnSpawn()
    {

    }
    public void OnHit()
    {

    }
    public void OnDelete()
    {

    }
}
