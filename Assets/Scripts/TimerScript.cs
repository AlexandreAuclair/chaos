using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    float time;

    void Awake()
    {
        time = 3f;
    }

    void Update()
    {
        GetComponent<Text>().text = time.ToString("0");

        time -= Time.deltaTime;

        if (time <= 0)
        {
            time = 0;
            time.ToString("Go");
        }
    }
}
