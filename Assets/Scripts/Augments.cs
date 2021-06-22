using UnityEngine;

[CreateAssetMenu(fileName = "New Augment", menuName = "Augment")]
public class Augments : MonoBehaviour
{
    public int boolDef;

    public EnemyHP enemyHP;
    public Weapon Weapon;
    public Hands currentweapon;
    public GameObject Effect;

    [Header("For Dot effects")]
    public int Lifetime;

    //get the Hit enemy from Weapon.cs
    //
    private void Awake()
    {
        currentweapon = GameObject.FindGameObjectWithTag("Hands").GetComponent<Hands>();
    }

    private void FixedUpdate()
    {
        IsFireOnHitAugment();
    }
    private bool isActive = false;
    public void IsFireOnHitAugment()
    {
       
        if (enemyHP != null && isActive == true)
        {
            
            for (int i = 0; i < Lifetime; i++)
            {
                if (boolDef == 1)
                {
                    enemyHP.currentHP -= 0.1f;
                    Effect = Instantiate(Effect, enemyHP.gameObject.transform.position, enemyHP.gameObject.transform.rotation);
                    Destroy(Effect, 10);
                    Debug.LogWarning("fire!!");
                    
                }
                if(i == Lifetime)
                {
                    isActive = false;
                }
            }
        }
    }

    private void Update()
    {
        enemyHP = currentweapon.Enemy;
        if(enemyHP != null)
        {
            isActive = true;
        }
    }
}