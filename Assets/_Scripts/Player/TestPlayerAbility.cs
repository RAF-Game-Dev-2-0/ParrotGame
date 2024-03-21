using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerAbility : MonoBehaviour
{
     Rigidbody rb;
    [SerializeField] float abilitySpeed;
    [SerializeField] float destroyAfter;
    [SerializeField] float acceleration;
    [SerializeField] float damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        if(!(rb = gameObject.GetComponent<Rigidbody>())){
            Debug.Log("add Rigidbody to" + this);
            return;
        }
        
        rb.velocity = transform.forward * abilitySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(acceleration != 0)
            rb.velocity += transform.forward * acceleration/100f;
        
        Invoke("DestroySelf", destroyAfter);
    }

    
    void OnTriggerEnter(Collider coll){
        var dmgThis = coll.GetComponent<IDamagable>();
        if(dmgThis != null){
        // Debug.Log(dmgThis);
            dmgThis.TakeDamage(damage, this.transform);
        DestroySelf();
        }
   }

    private void DestroySelf(){
        Destroy(this.gameObject);
    }

}
