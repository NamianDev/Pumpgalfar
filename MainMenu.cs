using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    SavePmkinClass SPC;
    JsonHelper JH;
    string PathRace;

    public Button Setting;
    public Button Load;

    private void Start()
    {
        PathRace = Path.Combine(Application.persistentDataPath, "PathPumgalfar.json"); 
        SPC = new SavePmkinClass();
        JH = new JsonHelper();
        if (!File.Exists(PathRace))
        {
            Debug.Log("Не Существует. Создаю");
            File.WriteAllText(PathRace, "");
            Load.interactable = false;
            SaveRace();
        }
        else
        {
            SPC = JH.JSONload(Path.Combine(Application.persistentDataPath, "PathPumgalfar.json"));
            if (SPC.Progress == 0)
            {
                Load.interactable = false;
            }

            Debug.Log("Успешно");
        }
        Setting.interactable = false;

    }
    public void StartButtonClick()
    {
        SaveRace();
        SceneManager.LoadScene(2);

    }
    public void ContunueButtonClick()
    {
        
        SceneManager.LoadScene(2);
    }
    public void SettingButtonClick()
    {

    }
    void SaveRace()
    {
        SPC.Day = 1;
        SPC.DayTime = 0;
        SPC.AllPeel = 0;
        SPC.AllSlaves = 0;
        SPC.AllSoulse = 0;
        SPC.Progress = 0;
        SPC.PowerSlaves = 0;
        SPC.PowerSpeed = 2;
        SPC.HellHunger = 0;
        SPC.DayTime = 240;
        SPC.ImageID = 0;
        SPC.RedesignedPeel = 0;
        JH.JSONsave(PathRace, SPC);
    }

}
