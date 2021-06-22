using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public float health;
    public float armor; //
    public float currentHP;
    private float damaged;

    public GameObject healthbarUI;
    public GameObject playerCam;
    public Slider slider;
    public int thisEnemy = 1;
    private EnemyIdentifier thatthing;

    // Start is called before the first frame update

    private void Awake()
    {
        playerCam = GameObject.FindGameObjectWithTag("MainCamera");
        thatthing = GameObject.Find("Scenemanager").GetComponent<EnemyIdentifier>();
        thatthing.AssignEnemy();
        health = EnemyIdentifier.healthPrefix;
        armor = EnemyIdentifier.armorPrefix;
    }
    void Start()
    {
       
       
        currentHP = health;
        armor = armor + 1;
        slider.value = CalculateHP();
        healthbarUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = CalculateHP();
        if(currentHP < health)
        {
            healthbarUI.SetActive(true);
        }
     if(currentHP <= 0)
        {
            Destroy(gameObject);
        }
        healthbarUI.transform.LookAt(playerCam.transform);

        if(currentHP < health)
        {
            Debug.Log(currentHP);
        }
    }
    public void TakeDamage(float damageTaken)
    {
        damaged = damageTaken / armor;
        currentHP -= damaged;
        
    }
    float CalculateHP()
    {
        return currentHP / health;
    }
}
