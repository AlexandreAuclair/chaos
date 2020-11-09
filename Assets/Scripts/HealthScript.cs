using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    private CharacterAnimations playerAnimation;
    public float health = 100f;

    private float x_Death = -90f;
    private float death_Smouth = 0.9f;
    private float rotate_Time = 0.23f;
    private bool playerDied;

    public bool isPlayer;

    [SerializeField]
    private Image health_UI;

    [HideInInspector]
    public bool shieldActivated;

    private CharacterSoundFX soundFX;

    void Awake()
    {
        soundFX = GetComponentInChildren<CharacterSoundFX>();
        playerAnimation = GetComponent<CharacterAnimations>();
    }

    void Update()
    {
        if (playerDied)
        {
            RotateAfterDeath();
        }
    }


    public void ApplyDamage(float damage)
    {
        if (shieldActivated)
        {
            health -= 1;
        }
        else
        {
        health -= damage;
        playerAnimation.Damage();
        }

        

        if(health_UI != null)
        {
            health_UI.fillAmount = health / 100f;
        }

   if (health <= 0){

            soundFX.Die();

            GetComponent<Animator>().enabled = false;

            //print("the character died");
            StartCoroutine(AllowRotate());

            if (isPlayer)
            {
                GetComponent<PlayerMove>().enabled = false;
                GetComponent<PlayerAttackInput>().enabled = false;

                //the player is not the parent game object
                //for the camera anymore
                Camera.main.transform.SetParent(null);

               // GameObject.FindGameObjectWithTag(Tags.ENEMY_TAG)
                   // .GetComponent<EnemyController>().enabled = false;
            }
            else
            {
                GetComponent<EnemyController>().enabled = false;
                GetComponent<NavMeshAgent>().enabled = false;
            }
        
        }
    }//apply damage

    void RotateAfterDeath()
    {
        transform.eulerAngles = new Vector3(
            Mathf.Lerp(transform.eulerAngles.x, x_Death, Time.deltaTime * death_Smouth),
            transform.eulerAngles.y, transform.eulerAngles.z);
    }

    IEnumerator AllowRotate()
    {
        playerDied = true;

        yield return new WaitForSeconds(rotate_Time);

        playerDied = false;
    }

}//class
