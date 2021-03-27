using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AbbadonScriptss : MonoBehaviour
{
    public int PeelCount;
    public int Slave;

    public Sprite[] ImagePumpin;

    public GameManager GM;
    public Controller Contrl;
    public GameObject Spawner;

    JsonHelper JH;
    TextAsset txtAsset;
    public int CurrentPumpID;
    PumpkingJSON PJ;
    SavePmkinClass SPC;

    private void Start()
    {
        SPC = new SavePmkinClass();
        JH = new JsonHelper();

        txtAsset = (TextAsset)Resources.Load(("PumpkinText"), typeof(TextAsset));
        StartCoroutine(SpawnCoroutine());
    }
    void OnTriggerEnter2D(Collider2D col) // скрипт на объекте:если Объект с тегом "Player" находится в триггере, то делаем что-то...
    {
        if (col.gameObject.tag == "Player")
        {
            Contrl.IsTriggerAbbadon = true;
          //  Debug.Log("Зашел");
        }
    }
    void OnTriggerExit2D(Collider2D col)//Если объект вышел из триггера и его тег "    Player"
    {
        if (col.gameObject.tag == "Player")
        {
            Contrl.IsTriggerAbbadon = false;
         //   Debug.Log("Вышел");
        }
    }

    void PumpkinSpawn(int PumpkinID)
    {
        string CardChildrenJson = JsonHelper.GetJsonObject(txtAsset.text, "pumpkin_" + PumpkinID);
        CurrentPumpID = PumpkinID;

        PJ = JsonUtility.FromJson<PumpkingJSON>(CardChildrenJson);
        Spawner.GetComponent<SpriteRenderer>().sprite = ImagePumpin[PJ.ImageID];
        Contrl.PumpkinTrue = true;
      //  SaveRace();
    }

    public void SaveRace()
    {
        SPC.Day = GM.Day;
        SPC.DayTime = GM.timeKeeper;
        SPC.AllPeel = GM.AllPeel;
        SPC.AllSlaves = GM.AllSlaves;
        SPC.AllSoulse = GM.AllSoulse;
        SPC.Progress = GM.Progress;
        SPC.PowerSlaves = GM.PowerSlaves;
        SPC.PowerSpeed = GM.PowerSpeed;
        SPC.HellHunger = GM.HellHunger;
        SPC.ImageID = CurrentPumpID;
        if (GM.EndGame == true)
        {
            SPC.Final = 1;
        }
        else if (GM.vin == 1)
        {
            SPC.Final = 2;
        }
        SPC.RedesignedPeel = GM.RedesignedPeel;
        JH.JSONsave(GM.PathRace, SPC);

    } //Сохранение забега

    public void LoadRace()
    {
        if (File.Exists(GM.PathRace))
        {
            SPC = JH.JSONload(GM.PathRace);
            GM.Day = SPC.Day;
            GM.AllPeel = SPC.AllPeel;
            GM.AllSlaves = SPC.AllSlaves;
            GM.AllSoulse = SPC.AllSoulse;
       //     GM.Progress = SPC.Progress;
            GM.PowerSlaves = SPC.PowerSlaves;
            GM.PowerSpeed = SPC.PowerSpeed;
            GM.HellHunger = SPC.HellHunger;
            GM.RedesignedPeel = SPC.RedesignedPeel;
            JH.JSONsave(GM.PathRace, SPC);
            Debug.Log("Успешно");
        }
    }
    IEnumerator SpawnCoroutine()
    {
            yield return new WaitForSeconds(Random.Range(8, 18));
            PumpkinSpawn(Random.Range(1,9));
        
        StartCoroutine(TimeToLiveCoroutine());
        StopCoroutine(this.SpawnCoroutine());
    }

    IEnumerator TimeToLiveCoroutine()
    {        yield return new WaitForSeconds(Random.Range(10, 16));
        CurrentPumpID = 0;
        Spawner.GetComponent<SpriteRenderer>().sprite = null;
        Contrl.PumpkinTrue = false;
        StartCoroutine(SpawnCoroutine());
        StopCoroutine(this.TimeToLiveCoroutine());
    }
}
