using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_col : MonoBehaviour
{
    private HealthScript healthScript;
    private GameObject thePlayer;
    private HealthScript healthScript2;
    private GameObject thePlayer2;

    void Awake()
    {
        thePlayer = GameObject.Find("gladiateur");
        healthScript = thePlayer.GetComponent<HealthScript>();

        thePlayer2 = GameObject.Find("gladiateur2");
        healthScript2 = thePlayer2.GetComponent<HealthScript>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "gladiateur")
        {
            healthScript.health += 30f;
            if (healthScript.health > 100f)
            {
                healthScript.health = 100f;
            };
            healthScript.health_UI.fillAmount = healthScript.health / 100f;
            
            Destroy(gameObject);
            Debug.Log("Giving P1 health");
        } 
        else if(collision.gameObject.name == "gladiateur2")
        {
            healthScript2.health += 30f;
            if (healthScript2.health > 100f)
            {
                healthScript2.health = 100f;
            };
            healthScript2.health_UI.fillAmount = healthScript2.health / 100f;
            Destroy(gameObject);
            Debug.Log("Giving P2 health");
        }
        
    }
}
