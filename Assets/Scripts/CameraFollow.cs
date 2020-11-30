using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    int zoom = 7;
    int zmoo = 20;
    int zom = 30;
    int normal = 48;
    int smooth = 1;
    public Transform other;

    public Camera mainCamera;

    [SerializeField]
    private Vector3 offsetPosition;


    void Awake()
    {
        //target = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        FollowPlayer();
    }

    //void Update()
    void Update()
    {
        if (other)
        {
            float dist = Vector3.Distance(other.position, transform.position);
            if (dist <= 1)
            {
                mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, zoom, Time.deltaTime * smooth);
               
            }
            if (dist <= 4)
            {
                mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, zmoo, Time.deltaTime * smooth);
            }
            if (dist <= 7)
            {
                mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, zom, Time.deltaTime * smooth);
            }
            if (dist >= 7)
            {
                mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, normal, Time.deltaTime * smooth);
            }
        }
    }
    //void FixedUpdate()



    void FollowPlayer()
    {
        //transform.position = target.TransformPoint(offsetPosition);
        //transform.rotation = target.rotation;
        
    }

}//class
