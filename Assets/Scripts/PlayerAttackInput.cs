using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{

    private CharacterAnimations playerAnimation;

    public GameObject attackPoint;

    private PlayerShield shield;

    private CharacterSoundFX soundFX;

    void Awake()
    {
        playerAnimation = GetComponent<CharacterAnimations>();
        shield = GetComponent<PlayerShield>();

        soundFX = GetComponentInChildren<CharacterSoundFX>();
    }

    // Update is called once per frame
    void Update()
    {
        //defend when J pressed
        if (Input.GetKeyDown(KeyCode.J))
        {
            defend();
        }

        if (Input.GetKeyUp(KeyCode.J))
        {
            defendNo();
        }

        if (Input.GetKeyDown(KeyCode.K))
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
            AttackLight();
        }
        if (Input.GetKeyDown(KeyCode.L))
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
        playerAnimation.Attack_1();
        soundFX.Attack_1();
    }

    void AttackHeavy()
    {
        playerAnimation.Attack_2();
        soundFX.Attack_2();
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
