using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

public class Controller : MonoBehaviour
{
    public bool IsTriggerAbbadon;
    public bool IsTriggerTable;
    public bool IsTriggerTrone;
    public AbbadonScriptss AS;
    public bool PumpkinTrue; // Наличие тыквы
    public float MoveSpeed;
    public GameManager GM;
    Rigidbody2D RB;
    Vector3 moveVector;
    Animator Anim;
    void Start()

    {
        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if (GM.vin != 0 || GM.EndGame)
        {
            AS.SaveRace();
            SceneManager.LoadScene(4);
        }
        if (Input.GetKey(KeyCode.E))
        {
            if (IsTriggerAbbadon && PumpkinTrue)
            {
                AS.SaveRace();
                SceneManager.LoadScene(1);
            }
            else if (IsTriggerTable && GM.Day >= 2)
            {
                Anim.Play("Hit");
                GM.TableHit = true;
            }
            else if (IsTriggerTrone)
            {
                AS.SaveRace();
                SceneManager.LoadScene(3);
            }
        }
        else if(!Input.GetKey(KeyCode.E) && IsTriggerTable)
        {
            GM.TableHit = false;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            GM.DebugResourse();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        NewMove();

    }
    void NewMove()
    {
        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");

        if (moveVector.x  == 1)
        {
            Anim.SetBool("RightMove", true);
            Anim.SetBool("LeftMove", false);
        }
        else if (moveVector.x  == -1)
        {
            Anim.SetBool("LeftMove", true);
            Anim.SetBool("RightMove", false);
        }
        else
        {
            Anim.SetBool("RightMove", false);
            Anim.SetBool("LeftMove", false);
        }
        if (moveVector.y  == 1)
        {
            Anim.SetBool("UpMove", true);
            Anim.SetBool("DownMove", false);
        }
        else if (moveVector.y == -1)
        {
            Anim.SetBool("UpMove", false);
            Anim.SetBool("DownMove", true);
        }
        else
        {
            Anim.SetBool("UpMove", false);
            Anim.SetBool("DownMove", false);
        }

        moveVector = moveVector.normalized * MoveSpeed;
        RB.MovePosition(RB.transform.position + moveVector);
    }
}
