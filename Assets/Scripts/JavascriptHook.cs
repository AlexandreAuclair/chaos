using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class JavascriptHook : MonoBehaviour
{
    [SerializeField] private Image PlayerHealthDisplay;

        public void TintRed()
    {
        PlayerHealthDisplay.color = Color.red;
    }

    public void TintBlue()
    {
        PlayerHealthDisplay.color = Color.blue;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TintRed();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            TintBlue();
        }
    }
}
