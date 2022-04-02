using System;
using GoogleSheetsToUnity;
using UnityEngine;

public class SeatService : Service<SeatService>
{
    [SerializeField] private string database = "1y-9T7SWcfza23S5HOilz6mTT0aPd2cgRLrZ9v7BJmBc";
    [SerializeField] private string key;
    [SerializeField] private SeatList list;
    public string Movie = "Morbius";
    public DateTime Date;
    public string Time = "10:30";
    public GstuSpreadSheet Data
    {
        get { return seatData; }
    }
    private GstuSpreadSheet seatData;
    public override void Init()
    {
        base.Init();
        //UpdateSeatingData();
    }
    
    public void UpdateSeatingData()
    {
        key = Movie + " " + string.Format("{0}{1}{2}", Date.Month, Date.Day, Date.Year) + " " + Time;
        SpreadsheetManager.Read(new GSTU_Search(database, key), OnSeatDataRespond);
    }

    public void UploadSeatingData()
    {
        foreach (var seat in seatData.Cells)
        {
            if ((Seat.Status) int.Parse(seat.Value.value) == Seat.Status.Selected)
            {
                //TODO: handle race condition of multiple user purchasing the same seat
                SpreadsheetManager.Write(new GSTU_Search(database, key, seat.Key), "1", UpdateSeatingData);
            }
        }
    }

    private void OnSeatDataRespond(GstuSpreadSheet response)
    {
        seatData = response;
        list.LoadSeatList();
    }
}
