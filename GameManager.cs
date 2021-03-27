using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public GameObject Tutorial;
    public float RoundLength;
    public int MaxPeelToShip;
    float PeelCountPerSecond;
    public float EatCount;
    public float RedesignedPeel;
    public Text debugTime;
    public Text debugDayAndProgress;
    public string PathRace;
    public GameObject Ship;
    public Sprite[] ShipSprite;
    public Image Dark;

    int minute;
    int second;
    public float timeKeeper;
    bool gameIsOver = false;
    SavePmkinClass SPC;
    JsonHelper JH;
    public bool TableHit;
    public Text GlobalResources;
    public GameObject ResourseSprite;
    float saveProgress;
    #region
    public int Day;
    public float AllPeel;
    public int AllSlaves;
    public float AllSoulse;
    [Range(0,100)]
    public float Progress;
    public int PowerSlaves;
    public float PowerSpeed;
    public float HellHunger;
    public int ImageID;
    public int vin;
    public bool EndGame;
    #endregion

    private void Awake()
    {
          StopAllCoroutines();
    }
    void Start()
    {
      
        PathRace = Path.Combine(Application.persistentDataPath, "PathPumgalfar.json");
        JH = new JsonHelper();
        LoadRace();


    }

    void FixedUpdate()
    {
        if (!this.gameIsOver)
        {
            this.timeKeeper -= 0.02f;
            minute = (int)(timeKeeper / 60);
            second = (int)(timeKeeper % 60);
            if (second < 10)
            {
                debugTime.text = minute + ":0" + second;
            }
            else
            {
                  debugTime.text = minute + ":" + second;
            }
          
            if (this.timeKeeper < 0f)
            {


                if (Day < 7)
                {
                    Day++;
                    this.timeKeeper = this.RoundLength;
                    Dark.GetComponent<Animator>().Play("Dark");
                }        
                else
                {
                    EndGame = true;
                    gameIsOver = true;
                }
            

            }
              
        }

        if (Progress <= 10)
        {
            Ship.GetComponent<SpriteRenderer>().sprite = null;
        }
        else if (Progress <= 25)
        {
            Ship.GetComponent<SpriteRenderer>().sprite = ShipSprite[0];
        }
        else if (Progress <= 50)
        {
            Ship.GetComponent<SpriteRenderer>().sprite = ShipSprite[1];
        }
        else if (Progress <= 75)
        {
            Ship.GetComponent<SpriteRenderer>().sprite = ShipSprite[2];
        }
        else if (Progress <= 90)
        {
            Ship.GetComponent<SpriteRenderer>().sprite = ShipSprite[3];
        }
        else if (Progress >= 100)
        {
            vin = 1;
        }
            
        debugDayAndProgress.text = Day + " День\r\n" + (int)Progress + "%";
    }
    public void LoadRace()
    {
        if (File.Exists(PathRace))
        {
            SPC = JH.JSONload(PathRace);
            Day = SPC.Day;
            timeKeeper = SPC.DayTime;
            AllPeel = SPC.AllPeel;
            AllSlaves = SPC.AllSlaves;
            AllSoulse = SPC.AllSoulse;
            RedesignedPeel = SPC.RedesignedPeel;
            saveProgress = SPC.Progress;
            PowerSlaves = SPC.PowerSlaves;
            PowerSpeed = SPC.PowerSpeed;
            HellHunger = SPC.HellHunger;
            Debug.Log("Успешно");
            StartCoroutine(BildShip());
            if (Day == 1)
            {
                StartCoroutine(Tutor());
            }
            if (Day >= 3)
            {
                 StartCoroutine(EatSouls());
            }

        }
    }

    public void DebugResourse()
    {
        if (ResourseSprite.activeSelf)
        {
            ResourseSprite.SetActive(false);
        }
        else
        {
            ResourseSprite.SetActive(true);
        GlobalResources.text = Day + " День\r\r\n"
          + "Ресурсы:\r\n"
          + (int)AllPeel + " кожуры\r\n"
          + AllSlaves + " рабов\r\n"
          + AllSoulse + " душ\r\n"
          + "Сила рабочих: " + PowerSlaves + "%\r\n"
          + "Сила ускорения: " + PowerSpeed + "x\r\n"
          + "Голод Хель: " + (int)(HellHunger * 100) + "%";
        }

     
    }

    public void ChangeDay()
    {
        switch (Day)
        { 
            case 4:
                PowerSpeed = 1.7f;
                break;
            case 5:
                EatCount = 1;
                break;
            case 6:
                break;
            case 7:
                break;

        }
    }
    IEnumerator BildShip()
    {
        while (true)
        {
            if (AllPeel != 0)
            {
                PeelCountPerSecond = (AllSlaves * ((float)PowerSlaves / 100)) * ((1 - HellHunger) + 0.1f);
                if (TableHit)
                {
                    if (AllPeel - PeelCountPerSecond * PowerSpeed >= 0)
                    {
                        AllPeel -= PeelCountPerSecond * PowerSpeed;
                        RedesignedPeel += PeelCountPerSecond * PowerSpeed;
                    }

                    else
                    {
                        AllPeel = 0;
                        RedesignedPeel += AllPeel;
                    }
                } //Ускорение
                else
                {
                    if (AllPeel - PeelCountPerSecond >= 0)
                    {
                        AllPeel -= PeelCountPerSecond;
                        RedesignedPeel += PeelCountPerSecond;
                    }
                    else
                    {
                        AllPeel = 0;
                        RedesignedPeel += AllPeel;
                    }

                }

                Progress = (RedesignedPeel / MaxPeelToShip) * 100;
                yield return new WaitForSeconds(1);
                if (RedesignedPeel >= MaxPeelToShip)
                {
                    RedesignedPeel = MaxPeelToShip;
                    break;
                }
            }
            else
            {
                break;
            }
        }
        StopCoroutine(this.BildShip());
    }

    IEnumerator EatSouls()
    {
        while (true)
        {
            if (AllSoulse - EatCount <= 0)
            {
                AllSoulse = 0;
                if (HellHunger >= 100)
                {
                    StopCoroutine(this.EatSouls());
                }
                HellHunger += 0.01f;
            }
            else
            {
               AllSoulse -= EatCount;
            }

            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator Tutor()
    {
        Tutorial.SetActive(true);
        yield return new WaitForSeconds(4);
        Tutorial.SetActive(false);
    }
}

