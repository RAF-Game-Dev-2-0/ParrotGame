using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDealDmg : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] BoxCollider ignoreColl;

    void OnTriggerEnter(Collider coll){
        if (coll != ignoreColl)
        {
            var dmgThis = coll.GetComponent<IDamagable>();
            if(dmgThis != null){
                dmgThis.TakeDamage(damage, this.transform);
            }
        }
   }

}
