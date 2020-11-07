using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{

    private Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Walk(bool walk)
    {
        anim.SetBool(AnimationTags.WALK_PARAMETER, walk);
    }

    public void Defend(bool defend)
    {
        anim.SetBool(AnimationTags.DEFEND_PARAMETER, defend);
    }
    public void TurnRight(bool tournerDroite)
    {
        anim.SetBool(AnimationTags.TURN_RIGHT, tournerDroite);
    }
    public void TurnLeft(bool tournerGauche)
    {
        anim.SetBool(AnimationTags.TURN_LEFT, tournerGauche);
    }

    public void Attack_1()
    {
        anim.SetTrigger(AnimationTags.ATTACK_TRIGGER_1);
    }

    public void Attack_2()
    {
        anim.SetTrigger(AnimationTags.ATTACK_TRIGGER_2);
    }

    public void Attack_3()
    {
        anim.SetTrigger(AnimationTags.ATTACK_TRIGGER_3);
    }

    public void Transition()
    {
        anim.SetTrigger(AnimationTags.ATTACK_TRANSITION);
    }
    public void Transition2()
    {
        anim.SetTrigger(AnimationTags.ATTACK_TRANSITION2);
    }


    void FreezeAnimation()
    {
        anim.speed = 0f;
    }

    public void UnFreezeAnimation()
    {
        anim.speed = 1f;
    }
}
