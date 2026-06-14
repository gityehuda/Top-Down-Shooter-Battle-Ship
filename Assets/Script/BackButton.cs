using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    [SerializeField] private GameObject CampaignMissionSelect;
    [SerializeField] private GameObject CampaignSelectionSelect;
    [SerializeField] private GameObject MissionSelect;
    [SerializeField] private GameObject preparation1;
    [SerializeField] private GameObject preparation2;
    [SerializeField] private SceneChange changeScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    public void BackFunction()
    {
        if (CampaignSelectionSelect.activeSelf == true)
        {
            changeScene.sceneName = "Main Menu";
            changeScene.ChangeScene();
        }
        else if (MissionSelect.activeSelf == true)
        {
            CampaignSelectionSelect.SetActive(true);
            MissionSelect.SetActive(false);
        }

        if (preparation1.activeSelf == true && CampaignMissionSelect.activeSelf == false)
        {
            MissionSelect.SetActive(true);
            preparation1.SetActive(false);
            CampaignSelectionSelect.SetActive(false);      
            CampaignMissionSelect.SetActive(true);     
        }
        else if (preparation2.activeSelf == true)
        {
            preparation1.SetActive(true);
            preparation2.SetActive(false);
        }
    }

}
