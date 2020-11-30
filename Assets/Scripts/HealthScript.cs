using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HealthScript : MonoBehaviour
{
    private CharacterAnimations playerAnimation;
    public float health = 100f;

    private float x_Death = -90f;
    private float death_Smouth = 0.9f;
    private float rotate_Time = 0.23f;
    private bool playerDied;

    public bool isPlayer;
    public GameObject text;

    [SerializeField]
    public Image health_UI;

    [HideInInspector]
    public bool shieldActivated;

    private CharacterSoundFX soundFX;
    public GameObject fanfareFin;
    public GameObject crowdFin;
    public float comboSoundCounter = 0;
   

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
            text.SetActive(true);
            StartCoroutine(GameOver());
            
        }
    }


    public IEnumerator ComboNoiseFunction() 
        {
            comboSoundCounter = 0;
            crowdFin.SetActive(true);
            yield return new WaitForSeconds(6f);
            crowdFin.SetActive(false);
        }

    public void ApplyDamage(float damage)
    {
        if (shieldActivated)
        {
            comboSoundCounter = 0;
            health -= 1;
            soundFX.Block();
        }
        else
        {
            comboSoundCounter++; 
            health -= damage;
            playerAnimation.Damage();
            soundFX.Hurt();
            if (comboSoundCounter >= 3)
            {
                StartCoroutine(ComboNoiseFunction());
            }
        }

      
        if(health_UI != null)
        {
            health_UI.fillAmount = health / 100f;
        }

   if (health <= 0){
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;
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

                if(sceneName == "gameplay")
                {
                    GameObject.FindGameObjectWithTag(Tags.ENEMY_TAG)
                     .GetComponent<EnemyController>().enabled = false;
                }
               
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

    public IEnumerator GameOver()
    {
        fanfareFin.SetActive(true);
        crowdFin.SetActive(true);
        yield return new WaitForSeconds(9f);
        SceneManager.LoadScene(0);
    }

    IEnumerator AllowRotate()
    {
        playerDied = true;
        yield return new WaitForSeconds(rotate_Time);
        playerDied = false;
    }

}//class
