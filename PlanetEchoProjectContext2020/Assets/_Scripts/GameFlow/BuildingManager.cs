using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;


[System.Serializable]
public class BuildingContainer
{
    public string name;
    public GameObject Building;
    public GameObject Inside;

    public BuildingContainer(string _name, GameObject _building, GameObject _inside)
    {
        name = _name;
        Building = _building;
        Inside = _inside;
    }

    public void Enter(bool enter)
    {
        if (enter)
        {
            Building.SetActive(false);
            Inside.SetActive(true);
        }
        else
        {
            Building.SetActive(true);
            Inside.SetActive(false);
        }
    }
}

public class BuildingManager : MonoBehaviour
{
    public List<BuildingContainer> Buildings;
    private GameObject building;

    
    public void SeeBuilding(GameObject buildingObject)
    {
        building = buildingObject;
    }

    private void Update()
    {
        if (building != null)
        {
            if (QuestLog.CurrentQuestState("Enter Building") == "success")// QuestState.Success))
            {
                EnterBuilding();
                QuestLog.SetQuestState("Enter Building", QuestState.Active);
            }

            if(QuestLog.CurrentQuestState("Exit Building") == "success")
            { 
                ExitBuilding();
                QuestLog.SetQuestState("Exit Building", QuestState.Active);
            }
        }
    }

    public void EnterBuilding()
    {
        //Code to run when entering building
        BuildingContainer buildingContainer = Buildings.Find(b => b.Building.Equals(building));
        buildingContainer.Enter(true);
    }

    public void ExitBuilding()
    {
        //Code to run when exiting building
        BuildingContainer buildingContainer = Buildings.Find(b => b.Building.Equals(building));
        buildingContainer.Enter(false);
    }
}
