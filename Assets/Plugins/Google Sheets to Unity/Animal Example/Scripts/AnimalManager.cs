using UnityEngine;
using System.Collections;
using GoogleSheetsToUnity;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;

/// <summary>
/// example script to show realtime updates of multiple items
/// </summary>
public class AnimalManager : MonoBehaviour
{
    public enum SheetStatus
    {
        PUBLIC,
        PRIVATE
    }
    public SheetStatus sheetStatus;

    public string associatedSheet = "1EQgLv9qRh9aXG48-V0g2xr3E6UMzJj4cP2Kf8Rc3NB8";
    public string associatedWorksheet = "Stats";

    public List<AnimalObject> animalObjects = new List<AnimalObject>();
    public AnimalContainer container;
    

    public bool updateOnPlay;

    void Awake()
    {
        if(updateOnPlay)
        {
           UpdateStats();
        }
    }

    void UpdateStats()
    {
        if (sheetStatus == SheetStatus.PRIVATE)
        {
            SpreadsheetManager.Read(new GSTU_Search(associatedSheet, associatedWorksheet), UpdateAllAnimals);
        }
        else if(sheetStatus == SheetStatus.PUBLIC)
        {
            SpreadsheetManager.ReadPublicSpreadsheet(new GSTU_Search(associatedSheet, associatedWorksheet), UpdateAllAnimals);
        }
    }

    void UpdateAllAnimals(GstuSpreadSheet ss)
    {
        foreach (Animal animal in container.allAnimals)
        {
            animal.UpdateStats(ss);
        }
        
        foreach(AnimalObject animalObject in animalObjects)
        {
            animalObject.BuildAnimalInfo();
        }
    }

}
