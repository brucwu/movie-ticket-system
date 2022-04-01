using GoogleSheetsToUnity;
using UnityEngine;

public class SeatService : Service<SeatService>
{
    [SerializeField] private string databaseId = "1y-9T7SWcfza23S5HOilz6mTT0aPd2cgRLrZ9v7BJmBc";
    [SerializeField] private string sheet = "03-31-2022";
    public override void Init()
    {
        base.Init();
        SpreadsheetManager.Read(new GSTU_Search(databaseId, sheet), UpdateSeatingData);
    }

    void UpdateSeatingData(GstuSpreadSheet data)
    {
        Debug.LogError(data["A1"].value);
        Debug.LogError(data["B2"].value);
        Debug.LogError(data["E3"].value);
    }
}
