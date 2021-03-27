using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SecondSceneControlller : MonoBehaviour
{
    string PathRace;
    JsonHelper JH;
    PumpkingJSON PJ;
    SavePmkinClass SPC;
    TextAsset txtAsset;
    public GameObject Spawner;
    public Sprite[] ImagePumpin;
    public Text GlobalResources;
    public Text LocalResources;
    void Start()
    {
        JH = new JsonHelper();
        PathRace = Path.Combine(Application.persistentDataPath, "PathPumgalfar.json");  //Ссылки на текстовые файлы, 1 - весь игровой контент, открывается единожды во время начаа забега, 2 - информация о забеге
        if (File.Exists(PathRace))
        {
            SPC = JH.JSONload(PathRace);
            Debug.Log("Успешно");
        }
        txtAsset = (TextAsset)Resources.Load(("PumpkinText"), typeof(TextAsset));
        PumpkinDebug(SPC.ImageID);
    }

    public void PeelButtonClick()
    {
        SPC.AllPeel += PJ.Peel;
        JH.JSONsave(PathRace, SPC);
        SwapScene();
    }


    public void SlavesButtonClick()
    {
        SPC.AllSlaves += 1;
        if (SPC.PowerSlaves < 100)
        {
            SPC.PowerSlaves = (SPC.PowerSlaves + PJ.BuildPower) / 2;
        }
        else
        {
            SPC.PowerSlaves = (SPC.PowerSlaves + PJ.BuildPower);
        }
        JH.JSONsave(PathRace, SPC);
        SwapScene();
    }
    public void SoulseButtonClick()
    {
        SPC.AllSoulse += PJ.Souls;
        JH.JSONsave(PathRace, SPC);
        SwapScene();
    }

    public void SwapScene()
    {
        SceneManager.LoadScene(2);
    }

    void PumpkinDebug(int PumpkinID)
    {
        string CardChildrenJson = JsonHelper.GetJsonObject(txtAsset.text, "pumpkin_" + PumpkinID);
        PJ = JsonUtility.FromJson<PumpkingJSON>(CardChildrenJson);
        Spawner.GetComponent<SpriteRenderer>().sprite = ImagePumpin[PJ.ImageID];
        DebugResources();
    }
    void DebugResources()
    {
        GlobalResources.text = SPC.Day + " День\r\r\n"
            + "Ресурсы:\r\n"
            + (int)SPC.AllPeel + " кожуры\r\n"
            + SPC.AllSlaves + " рабов\r\n"
            + SPC.AllSoulse + " душ\r\n"
            + "Прогресс постройки: " + (int)SPC.Progress + "%\r\n"
            + "Сила рабочих: " + SPC.PowerSlaves + "%\r\n"
            + "Сила ускорения: " + SPC.PowerSpeed + "x\r\n"
            + "Голод Хель: " + SPC.HellHunger * 100 + "%";
        LocalResources.text = "Свойства тыквы:\r\n"
            + PJ.Peel + " кожуры\r\n"
            + PJ.Souls + " душ\r\n"
            + "Сила раба: " + PJ.BuildPower;
}


}
