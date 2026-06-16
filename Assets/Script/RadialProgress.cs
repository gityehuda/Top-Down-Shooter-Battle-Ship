using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RadialProgress : MonoBehaviour
{
    public PlayerController controller;
    [SerializeField] private TMP_Text reloadText;
    private Image circularBar;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        circularBar = GetComponent<Image>();                                        
    }
    float currentValue;
    // Update is called once per frame
    void Update()
    {
        ReloadText();
        RadialTimer();                  
    }

    private void ReloadText()
    {

        controller.timer = Math.Round(controller.timer, 2);
        if (controller.timer > 0)
        {
            reloadText.gameObject.SetActive(true);
            reloadText.text = controller.timer.ToString() + "\nReloading";
        }
        else
        {
            reloadText.gameObject.SetActive(false);
        }
    }

    private void RadialTimer()
    {
        if(controller.timer > 0)
        {
            gameObject.GetComponent<Image>().enabled = true;         
            circularBar.fillAmount = (float)controller.timer / controller.fireRate;        
                          
        }
        else
        {
            gameObject.GetComponent<Image>().enabled = false;  
        }
    }

}
