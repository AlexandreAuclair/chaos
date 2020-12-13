using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{

    private CharacterAnimations playerAnimation;

    public GameObject attackPoint;

    private PlayerShield shield;

    private HealthScript healthScript;

    private CharacterSoundFX soundFX;
private bool a = false;
    void Awake()
    {
        playerAnimation = GetComponent<CharacterAnimations>();
        shield = GetComponent<PlayerShield>();
        healthScript = GetComponent<HealthScript>();
        soundFX = GetComponentInChildren<CharacterSoundFX>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //defend when J pressed
        if (Input.GetKeyDown(KeyCode.Z))
        {
            defend();
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            defendNo();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            //if(Random.Range(0, 2) > 0)
            //{
            // playerAnimation.Attack_1();
            //soundFX.Attack_1();
            //}
            //else
            //{
            //playerAnimation.Attack_2();
            //soundFX.Attack_2();
            //}
            if (a == true)
            {
                Transition();
                a = false;
            }
            AttackLight();
            
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            AttackHeavy();
        }
    }

    void defend()
    {
        playerAnimation.Defend(true);

        shield.ActivateShield(true);
    }

    void defendNo()
    {
        playerAnimation.UnFreezeAnimation();
        playerAnimation.Defend(false);

        shield.ActivateShield(false);
    }
    void AttackLight()
    {
        if(healthScript.shieldActivated == false)
        {
            if (playerAnimation.anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
            {
                soundFX.Attack();
            }

            playerAnimation.Attack_1(); 
            a = true;
        }     
    }
    void AttackLight2()
    {
        if (healthScript.shieldActivated == false)
        {
            playerAnimation.Attack_3();
            soundFX.Attack();
        }   
    }

    void AttackHeavy()
    {
        if (healthScript.shieldActivated == false)
        {
            playerAnimation.Attack_4();
              soundFX.Attack();
        }   
    }
    void Transition()
    {
        playerAnimation.Transition();
        soundFX.Attack();
    }

    void Activate_AttackPoint()
    {
        attackPoint.SetActive(true);
    }

    void Deactivate_AttackPoint()
    {
        if (attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }
    }

}//class
