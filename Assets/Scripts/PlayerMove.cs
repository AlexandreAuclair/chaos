using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController charController;
    private CharacterAnimations playerAnimations;

    public float movement_Speed = 3f;
    public float gravity = 9.8f;
    public float rotation_Speed = 0.15f;
    public float rotateDegreesPerSecond = 180f;
    
    //first functtion that is called
    void Awake()
    {
        charController = GetComponent<CharacterController>();
        playerAnimations = GetComponent<CharacterAnimations>();
    }
    //second function that is called
   // void OnEnable()

    //third function that is called
   // void Start()

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        AnimateWalk();
    }

    void Move()
    {
        //print("the value is" + Input.GetAxisRaw("Vertical"));

        if(Input.GetAxis(Axis.VERTICAL_AXIS) > 0)
        {
            Vector3 moveDirection = transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;

            charController.Move(moveDirection * movement_Speed * Time.deltaTime);

        }
        else if(Input.GetAxis(Axis.VERTICAL_AXIS) < 0)
        {
            Reculer();
        }
        else
        {
            charController.Move(Vector3.zero);
        }

    }//move

    void Avancer()
    {
        Vector3 moveDirection = transform.forward;
        moveDirection.y -= gravity * Time.deltaTime;

        charController.Move(moveDirection * movement_Speed * Time.deltaTime);

    }
    void Reculer()
    {
        Vector3 moveDirection = -transform.forward;
        moveDirection.y -= gravity * Time.deltaTime;

        charController.Move(moveDirection * movement_Speed * Time.deltaTime);
        playerAnimations.Walk(true);
    }

   public void Rotate()
    {

        Vector3 rotation_Direction = Vector3.zero;

        if(Input.GetAxis(Axis.HORIZONTAL_AXIS) < 0)
        {
            TournerGauche();
        }
        
        if (Input.GetAxis(Axis.HORIZONTAL_AXIS) > 0)
        {
            TournerDroite();
        }
        if(rotation_Direction != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, Quaternion.LookRotation(rotation_Direction),
                rotateDegreesPerSecond * Time.deltaTime);
        }


    }//rotate

    void TournerGauche()
    {
        Vector3 rotation_Direction = Vector3.zero;
        rotation_Direction = transform.TransformDirection(Vector3.left);
        if (rotation_Direction != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, Quaternion.LookRotation(rotation_Direction),
                rotateDegreesPerSecond * Time.deltaTime);
        }
    }
    void TournerDroite()
    {
        Vector3 rotation_Direction = Vector3.zero;
        rotation_Direction = transform.TransformDirection(Vector3.right);
        if (rotation_Direction != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, Quaternion.LookRotation(rotation_Direction),
                rotateDegreesPerSecond * Time.deltaTime);
        }
    }

    void AnimateWalk()
    {
        if(charController.velocity.sqrMagnitude != 0f)
        {
            playerAnimations.Walk(true);
        }
        else
        {
            playerAnimations.Walk(false);
        }
    }

}//class
