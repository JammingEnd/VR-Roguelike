using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdentifier : MonoBehaviour
{
    public int enemyNumber; //1 is normal, 2 is speedy, 3 is tank etc;
    public static float healthPrefix;
    public static float speedPrefix;
    public static float armorPrefix;

    private GameObject enemy;
  public void AssignEnemy()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyNumber = enemy.GetComponent<EnemyHP>().thisEnemy;
       
        if (enemy != null)
        {

            if(enemyNumber == 1)
            {
                healthPrefix = 100;
                speedPrefix = 80;
                armorPrefix = 0;

            }
        }
    }
}
