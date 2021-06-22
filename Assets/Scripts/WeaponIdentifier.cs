using UnityEngine;

public class WeaponIdentifier : MonoBehaviour
{
    public int weaponNumber; //1 is heavy, 2 is long, 3 is short.
    public static float cooldownSwingPrefix;
    public static float damagePrefix;
    public static float critPrefix;
    public static int maxAttr;
    private GameObject getWeapons;

    public void AssingWeapon()
    {
       
        getWeapons = GameObject.FindGameObjectWithTag("Weapon");
        weaponNumber = getWeapons.GetComponent<Weapon>().thisWeapon;
        if (getWeapons != null)
        {
            maxAttr = Random.Range(2, 6);


            if (weaponNumber == 1)
            {
                cooldownSwingPrefix = 1;
                damagePrefix = 45;
                critPrefix = 2;
            }
            if (weaponNumber == 2)
            {
                cooldownSwingPrefix = 0.6f;
                damagePrefix = 30;
                critPrefix = 1.5f;
            }
            if (weaponNumber == 3)
            {
                cooldownSwingPrefix = 0.4f;
                damagePrefix = 20;
                critPrefix = 1.5f;
                
            }
        }
        else
        {
            return;
        }
    }
}
 