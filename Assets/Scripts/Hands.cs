using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    public Weapon currentWeapon;
    public EnemyHP Enemy;
    public Collision collision;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Weapon")
        {
            currentWeapon = other.gameObject.GetComponent<Weapon>();
        }
        collision = currentWeapon.Collision;
        Enemy = collision.gameObject.GetComponent<EnemyHP>();
    }
    private void OnTriggerExit(Collider other)
    {
        currentWeapon = null;
    }
    private void Update()
    {
   
            
            
        
    }
}
