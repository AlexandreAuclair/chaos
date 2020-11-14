using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSoundFX : MonoBehaviour
{

    private AudioSource soundFX;

    [SerializeField]
    private AudioClip
        attack_Sound_1,
        attack_Sound_2,
        attack_Sound_3,
        hurt_Sound_1,
        hurt_Sound_2,
        hurt_Sound_3,
        block_Sound_1,
        block_Sound_2,
        block_Sound_3,
        die_Sound_1,
        die_Sound_2,
        die_Sound_3,
        fanfare_fin;
    void Awake()
    {
        soundFX = GetComponent<AudioSource>();
    }

    public void Attack()
    {
        int random;
        random = Random.Range(1, 3);
        switch (random)
        {
            case 1:
                soundFX.clip = attack_Sound_1;
                soundFX.Play();
                break;
            case 2:
                soundFX.clip = attack_Sound_2;
                soundFX.Play();
                break;
            case 3:
                soundFX.clip = attack_Sound_3;
                soundFX.Play();
                break;
        }
    }

    

    public void Hurt()
    {
        int random;
        random = Random.Range(1, 3);
        switch (random)
        {
            case 1: 
                soundFX.clip = hurt_Sound_1;
                soundFX.Play();
                break;
            case 2: 
                soundFX.clip = hurt_Sound_2;
                soundFX.Play();
                break;
            case 3: 
                soundFX.clip = hurt_Sound_3;
                soundFX.Play();
                break;
        } 
    }

    public void Block()
    {
        int random;
        random = Random.Range(1, 3);
        switch (random)
        {
            case 1:
                soundFX.clip = block_Sound_1;
                soundFX.Play();
                break;
            case 2:
                soundFX.clip = block_Sound_2;
                soundFX.Play();
                break;
            case 3:
                soundFX.clip = block_Sound_3;
                soundFX.Play();
                break;
        }
    }

    public void Die()
    {
        int random;
        random = Random.Range(1, 3);
        switch (random)
        {
            case 1:
                soundFX.clip = die_Sound_1;
                soundFX.Play();
                break;
            case 2:
                soundFX.clip = die_Sound_2;
                soundFX.Play();
                break;
            case 3:
                soundFX.clip = die_Sound_3;
                soundFX.Play();
                break;
        }
    }

   
}//class
