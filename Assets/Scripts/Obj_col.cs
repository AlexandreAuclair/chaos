using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_col : MonoBehaviour
{
    private HealthScript healthScript;
    private GameObject thePlayer;

    void Awake()
    {
        thePlayer = GameObject.Find("gladiateur");
        healthScript = thePlayer.GetComponent<HealthScript>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "gladiateur")
        {
            healthScript.health += 30f;
            Destroy(gameObject);
        }
        
    }
}
