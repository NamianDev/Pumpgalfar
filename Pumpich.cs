using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class Pumpich : MonoBehaviour
{
    public Sprite[] pumpich;
    public GameObject GO;
    public Text text;

    SavePmkinClass SPC;
    JsonHelper JH;
    // Start is called before the first frame update
    void Start()
    {
        JH = new JsonHelper();
        SPC = JH.JSONload(Path.Combine(Application.persistentDataPath, "PathPumgalfar.json"));
        if (SPC.Final == 2)
        {
            GO.GetComponent<SpriteRenderer>().sprite = pumpich[0];
            text.text = "Дух хеллоуина витает в воздухе. Хеллоуин спасен! Нажмите ESC";
        }
        else if(SPC.Final == 1)
        {
            GO.GetComponent<SpriteRenderer>().sprite = pumpich[1];
            text.text = "Хеллоуин навсегда исчез. Мы не справились. Нажмите ESC";
        }
        Debug.Log("Успешно");
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        } 
    }
}
