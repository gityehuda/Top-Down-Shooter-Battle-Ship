using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private GameObject PauseWindow;         
    private bool isMouseOver = false;   


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (PauseWindow.activeSelf == true && isMouseOver == false)
        //{
        //    controller.enabled = false;
        //}
    }


    private void OnMouseExit()
    {
                                                    
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
                  
            controller.enabled = false; 
            isMouseOver = true; 
      
      
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
            controller.enabled = true;
            isMouseOver = false;                    
       
    }
}
