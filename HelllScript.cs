using System.Collections;
using System.Collections.Generic; 
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class HelllScript : MonoBehaviour
{
    JsonHelper JH;
    SavePmkinClass SPC;
    int Day;
    HellJSON HJ;
    string PathRace;
    TextAsset txtAsset;
    public Text Help;
    void Start()
    {
        PathRace = Path.Combine(Application.persistentDataPath, "PathPumgalfar.json");

        JH = new JsonHelper();

        txtAsset = (TextAsset)Resources.Load(("HelpHell"), typeof(TextAsset));
        Load();
        StartCoroutine(DebugHelp());
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopAllCoroutines();
            SceneManager.LoadScene(2);
        }
    }
    private void Load()
    {
        if (File.Exists(PathRace))
        {
            SPC = JH.JSONload(PathRace);
            Day = SPC.Day;
            Debug.Log("Успешно");
        }
    }
    IEnumerator DebugHelp()
    {
        int i;
        Debug.Log(Day);
        switch (Day)
        {
            case 1:
                for (i = 1; i <= 4; i++)
                {
                string CardChildrenJson = JsonHelper.GetJsonObject(txtAsset.text, "Help_" + i);
                HJ = JsonUtility.FromJson<HellJSON>(CardChildrenJson);
                 for (int a = 1; a <= 3; a++)
            {
                switch (a)
                {
                    case 1:
                        Help.text = HJ.Text1;
                        break;
                    case 2:
                        Help.text = HJ.Text2;
                        break;
                    case 3:
                        Help.text = HJ.Text3;
                        break;
                }
                yield return new WaitForSeconds(Random.Range(5,8));
            }

                }
            break;
            case 2:
                for (i = 5; i <= 6; i++)
                {
                    string CardChildrenJson = JsonHelper.GetJsonObject(txtAsset.text, "Help_" + i);
                    HJ = JsonUtility.FromJson<HellJSON>(CardChildrenJson);
                    for (int a = 1; a <= 3; a++)
                    {
                        switch (a)
                        {
                            case 1:
                                Help.text = HJ.Text1;
                                break;
                            case 2:
                                Help.text = HJ.Text2;
                                break;
                            case 3:
                                Help.text = HJ.Text3;
                                break;
                        }
                        yield return new WaitForSeconds(Random.Range(5, 8));
                    }

                }
                break;
            case 3:
                for (i = 7; i <= 8; i++)
                {
                    string CardChildrenJson = JsonHelper.GetJsonObject(txtAsset.text, "Help_" + i);
                    HJ = JsonUtility.FromJson<HellJSON>(CardChildrenJson);
                    for (int a = 1; a <= 3; a++)
                    {
                        switch (a)
                        {
                            case 1:
                                Help.text = HJ.Text1;
                                break;
                            case 2:
                                Help.text = HJ.Text2;
                                break;
                            case 3:
                                Help.text = HJ.Text3;
                                break;
                        }
                        yield return new WaitForSeconds(Random.Range(5, 8));
                    }

                }
                break;
            case 4:
                for (i = 9; i <= 10; i++)
                {
                    string CardChildrenJson = JsonHelper.GetJsonObject(txtAsset.text, "Help_" + i);
                    HJ = JsonUtility.FromJson<HellJSON>(CardChildrenJson);
                    for (int a = 1; a <= 3; a++)
                    {
                        switch (a)
                        {
                            case 1:
                                Help.text = HJ.Text1;
                                break;
                            case 2:
                                Help.text = HJ.Text2;
                                break;
                            case 3:
                                Help.text = HJ.Text3;
                                break;
                        }
                        yield return new WaitForSeconds(Random.Range(5, 8));
                    }

                }
                break;
            case 5:
                for (i = 11; i <= 12; i++)
                {
                    string CardChildrenJson = JsonHelper.GetJsonObject(txtAsset.text, "Help_" + i);
                    HJ = JsonUtility.FromJson<HellJSON>(CardChildrenJson);
                    for (int a = 1; a <= 3; a++)
                    {
                        switch (a)
                        {
                            case 1:
                                Help.text = HJ.Text1;
                                break;
                            case 2:
                                Help.text = HJ.Text2;
                                break;
                            case 3:
                                Help.text = HJ.Text3;
                                break;
                        }
                        yield return new WaitForSeconds(Random.Range(5, 8));
                    }

                }
                break;
            case 6:
                for (i = 13; i <= 13; i++)
                {
                    string CardChildrenJson = JsonHelper.GetJsonObject(txtAsset.text, "Help_" + 13);
                    HJ = JsonUtility.FromJson<HellJSON>(CardChildrenJson);
                    for (int a = 1; a <= 3; a++)
                    {
                        switch (a)
                        {
                            case 1:
                                Help.text = HJ.Text1;
                                break;
                            case 2:
                                Help.text = HJ.Text2;
                                break;
                            case 3:
                                Help.text = HJ.Text3;
                                break;
                        }
                        yield return new WaitForSeconds(Random.Range(5, 8));
                    }

                }
                break;
            case 7:
                for (i = 14; i <= 14; i++)
                {
                    string CardChildrenJson = JsonHelper.GetJsonObject(txtAsset.text, "Help_" + i);
                    HJ = JsonUtility.FromJson<HellJSON>(CardChildrenJson);
                    for (int a = 1; a <= 3; a++)
                    {
                        switch (a)
                        {
                            case 1:
                                Help.text = HJ.Text1;
                                break;
                            case 2:
                                Help.text = HJ.Text2;
                                break;
                            case 3:
                                Help.text = HJ.Text3;
                                break;
                        }
                        yield return new WaitForSeconds(Random.Range(5, 8));
                    }

                }
                break;
        }

           StopAllCoroutines();
    }
}
