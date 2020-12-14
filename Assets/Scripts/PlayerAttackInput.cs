using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{
    private CharacterAnimations playerAnimation;
    public GameObject enemyAnimation;
    public GameObject attackPoint1;
    public GameObject attackPoint2;
    private PlayerShield shield;
    private HealthScript healthScript;
    private CharacterSoundFX soundFX;
    private bool canAttack = true;
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
        if (playerAnimation.anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            canAttack = true;
        } else if (!playerAnimation.anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            canAttack = false;
        }

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
            if (canAttack == true)
            {
                if (a == true)
                {
                    Transition();
                    a = false;
                }
                AttackLight();
            }
        }
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (canAttack == true)
            {
                AttackHeavy();
            }
        }
    }

    void defend()
    {
        CharacterAnimations component = enemyAnimation.GetComponent<CharacterAnimations>();
        playerAnimation.Defend(true);
        
        shield.ActivateShield(true);

        component.Damage(true);
        StartCoroutine(desactive());
        
    }
    public IEnumerator desactive()
    {
        CharacterAnimations component = enemyAnimation.GetComponent<CharacterAnimations>();
        yield return new WaitForSeconds(1f);
        component.Damage(false);
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
            soundFX.Attack();
            playerAnimation.Attack_1(); 
            a = true;
        }     
    }
    void AttackLight2()
    {
        if (healthScript.shieldActivated == false)
        {
            soundFX.Attack();
            playerAnimation.Attack_3();
        }   
    }

    void AttackHeavy()
    {
        if (healthScript.shieldActivated == false)
        {
            soundFX.Attack();
            playerAnimation.Attack_4();
        }   
    }

    void Transition()
    {
        playerAnimation.Transition();
    }

    void Activate_AttackPoint1()
    {
        attackPoint1.SetActive(true);
    }

    void Deactivate_AttackPoint1()
    {
        if (attackPoint1.activeInHierarchy)
        {
            attackPoint1.SetActive(false);
        }
    }
    
    void Activate_AttackPoint2()
    {
        attackPoint2.SetActive(true);
    }

    void Deactivate_AttackPoint2()
    {
        if (attackPoint2.activeInHierarchy)
        {
            attackPoint2.SetActive(false);
        }
    }

}//class
