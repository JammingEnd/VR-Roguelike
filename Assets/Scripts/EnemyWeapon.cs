using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{



    [Header("projectile stats")]
    public LayerMask collisionMask;
    public bool isProjectile;
    public float velocity;
    private bool weaponhit = false;
    bool groundHit = false;
    private void Update()
    {
        if(isProjectile != false)
        {
            if(!groundHit)
            {
             //   transform.position += transform.forward * velocity * Time.deltaTime;
            }
            else
            {
                transform.position = transform.position;
               
                Destroy(gameObject);
                //instantiate destroyeffect
            }


            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (weaponhit == true)
            {
                if (Physics.Raycast(ray, out hit, Time.deltaTime * velocity + .1f, collisionMask))
                {
                    Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
                    float rot = -90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
                    Vector3 eulAng = new Vector3(0, rot, 0);
                    transform.eulerAngles = eulAng;
                   
                }

            }
           

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            //bounce off the blade
            weaponhit = true;

            //if sword do a slight knockback
        }
        if (other.gameObject.tag == "Player")
        {
            //damage the player etc

        }
        if(other.gameObject.tag == "Enemy")
        {
            // Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 8)
        {
            groundHit = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
       weaponhit = false;
    }
}
