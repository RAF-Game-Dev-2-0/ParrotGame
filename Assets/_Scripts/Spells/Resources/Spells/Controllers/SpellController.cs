using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellController : MonoBehaviour
{
    public abstract void OnSpawn();
    public abstract void OnHit();
}
