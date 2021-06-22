using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage;
    public float swingCooldown;
    public float critDamage;
    private float currentCD;
    private float finalDamage;
    public int maxAttributes;
    public GameObject weaponPrefab;
    public GameObject hitEffect;
    private bool OnCD;
    public int thisWeapon = 3;
    public WeaponIdentifier thisthing;
    public bool isHit;
    public Collision Collision;

    // Start is called before the first frame update
    private void Awake()
    {
        thisthing = GameObject.Find("Scenemanager").GetComponent<WeaponIdentifier>();
        thisthing.AssingWeapon();
        damage = WeaponIdentifier.damagePrefix;
        swingCooldown = WeaponIdentifier.cooldownSwingPrefix;
        critDamage = WeaponIdentifier.critPrefix;
        currentCD = swingCooldown;
        finalDamage = damage;
        maxAttributes = WeaponIdentifier.maxAttr;
        AttributeHandler();

        //here go the random + attributes
    }

    void AttributeHandler()
    {
        for (int i = 0; i < maxAttributes; i++)
        {
          int attrIdentifier = Random.Range(1, 4);
            if(attrIdentifier == 1)
            {
                damage = damage * 1.3f;
            }
            if(attrIdentifier == 2)
            {
                swingCooldown = swingCooldown * 0.9f;
            }
            if(attrIdentifier == 3)
            {
                critDamage = critDamage * 1.2f;
            }
   
        }
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            this.Collision = collision;
            ContactPoint contactPoint = collision.GetContact(0);
         
            float rigidBodyVelocity = collision.impulse.magnitude;
            DamageCalc(damage);

           
           
            Collision.gameObject.GetComponent<EnemyHP>().TakeDamage(finalDamage);

            isHit = true;
            OnCD = true;
        }
    }
    void DamageCalc(float impulse)
    {
        int critChance = Random.Range(1, 21);
        if(critChance != 1)
        {
            critDamage = 1;
        }
        finalDamage = damage * (impulse * 10) * critDamage;
        Debug.Log(finalDamage);
        hitEffect = Instantiate(hitEffect, transform.position, Quaternion.FromToRotation(Vector3.up, transform.position));
        Destroy(hitEffect, 3); ;
    }
    private void FixedUpdate()
    {
        if (OnCD == true)
        {
            float i;
            i = swingCooldown / 10;
            currentCD = currentCD - i;
            if (currentCD <= 0)
            {
                currentCD = swingCooldown;
                OnCD = false;
                Debug.LogWarning("CD over");
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        isHit = false;
        collision = null;
    }
}