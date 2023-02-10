using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class dectecting : enmycontrol
{
    public float bulletSpeed = 50f;
    public GameObject bulletPrefab;
    
    internal override void OnTriggerEnter(Collider collision)
    {

        base.OnTriggerEnter( collision);

       
       
        if (!bulletPrefab) return;

        GameObject bullet = Instantiate(bulletPrefab, transform);
      bullet.GetComponent<Rigidbody>().AddForce(transform.forward* bulletSpeed, ForceMode.Impulse);
        bullet.transform.parent = null;
        
    }
}
