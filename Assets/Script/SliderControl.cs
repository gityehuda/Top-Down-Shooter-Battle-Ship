using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    public double decelerationRate;
    [SerializeField]private TMP_Text decelerationText;
    public double turningSpeed;
    [SerializeField]private TMP_Text turningText;
    public double movingSpeed;
    [SerializeField]private TMP_Text speedText;
    public PlayerController playerController;

    [Header("Slider")]
    public Slider movingSpeedSlider;
    public Slider turningSpeedSlider;
    public Slider decelerationRateSlider;

    // Startis called before the first frame update
    void Start()
    {
        //movingSpeed = playerController.moveSpeed;
        //turningSpeed = playerController.turningSpeed;
        //decelerationRate = playerController.decelerationRate;

    }

    // Update is called once per frame
    void Update()
    {
        movingSpeed = movingSpeedSlider.value; 
        speedText.text = Math.Round(movingSpeed, 2).ToString();
        turningSpeed = turningSpeedSlider.value;        
        turningText.text = Math.Round(turningSpeed, 2).ToString();
        decelerationRate = decelerationRateSlider.value;                        
        decelerationText.text = Math.Round(decelerationRate, 2).ToString();
  
    }
}
