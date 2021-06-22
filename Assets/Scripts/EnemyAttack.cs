using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    bool isBowman;
    public GameObject projectile;
    public Transform firePoint;
    bool alreadyAttacked;
    private EnemyAI AI;
    private float projectileLifetime;
    private float fireSpeed;
    public float velocity = 16f;
    private void Awake()
    {
        AI = gameObject.GetComponent<EnemyAI>();

        isBowman = AI.isBowman;
        projectileLifetime = AI.projectileLifetime;
        fireSpeed = AI.fireSpeed;
        
    }
    public void Attack() { 
     if (!alreadyAttacked)
        {
            if (isBowman)
            {
             
               Rigidbody rb = Instantiate(projectile, firePoint.position, Quaternion.identity).GetComponent<Rigidbody>();
               rb.AddForce(firePoint.forward * 16f, ForceMode.Impulse);
               rb.AddForce(firePoint.up* 4f, ForceMode.Impulse);
               
              // Destroy(projectile, projectileLifetime);
}

              alreadyAttacked = true;
              Invoke(nameof(ResetAttack), fireSpeed);
        }
    }

    void ResetAttack()
{
    alreadyAttacked = false;
}

}
