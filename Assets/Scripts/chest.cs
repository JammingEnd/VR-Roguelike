using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
  [SerializeField]  private Animator anim;
    
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.name == "Right C" || collision.gameObject.name == "Left C")
        {
            Debug.Log("play");
            anim.SetBool("startBool", true);
        }
       
    }
}
