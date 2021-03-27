using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;
public class PumpkingJSON
{
    public int Peel;
    public int BuildPower;
    public int Souls;
    public string Name;
    public int ImageID;
}
public class SavePmkinClass
{ 
    public int Day;
    public float DayTime;
    public float AllPeel;
    public int AllSlaves;
    public float AllSoulse;
    public float Progress;
    public float RedesignedPeel;
    public int PowerSlaves;
    public float PowerSpeed;
    public float HellHunger;
    public int ImageID;
    public int Final;
}

public class HellJSON
{
    public string Text1;
    public string Text2;
    public string Text3;
}

public class JsonHelper
{

    public static string GetJsonObject(string jsonString, string handle)
    {
        string pattern = "\"" + handle + "\"\\s*:\\s*\\{";

        Regex regx = new Regex(pattern);

        Match match = regx.Match(jsonString);

        if (match.Success)
        {
            int bracketCount = 1;
            int i;
            int startOfObj = match.Index + match.Length;
            for (i = startOfObj; bracketCount > 0; i++)
            {
                if (jsonString[i] == '{') bracketCount++;
                else if (jsonString[i] == '}') bracketCount--;
            }
            return "{" + jsonString.Substring(startOfObj, i - startOfObj);
        }

        //no match, return null
        return null;
    }


    public void JSONsave(string path, SavePmkinClass PJSON)
    {
        //   Debug.Log("Saver path - " + path);
        var JSON = JsonUtility.ToJson(PJSON, true);
        Debug.Log("Saver string - " + JSON);
        File.WriteAllText(path, JSON);
    }
    public SavePmkinClass JSONload(string path)
    {
        return JsonUtility.FromJson<SavePmkinClass>(File.ReadAllText(path));
    }
}
