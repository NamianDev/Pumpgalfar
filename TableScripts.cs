using UnityEngine;

public class TableScripts : MonoBehaviour
{
    public Controller Contrl;
    void OnTriggerEnter2D(Collider2D col) // скрипт на объекте:если Объект с тегом "Player" находится в триггере, то делаем что-то...
    {
        if (this.gameObject.tag == "Trone" && col.gameObject.tag == "Player")
        {
            Contrl.IsTriggerTrone = true;
        }
        else
        {
          if (col.gameObject.tag == "Player")
          {
            Contrl.IsTriggerTable = true;
          }
        }

    }
    void OnTriggerExit2D(Collider2D col)//Если объект вышел из триггера и его тег "    Player"
    {
        if (this.gameObject.tag == "Trone" && col.gameObject.tag == "Player")
        {
            Contrl.IsTriggerTrone = false;
        }
        else if (col.gameObject.tag == "Player")
        {
            Contrl.IsTriggerTable = false;
        }
    }

}
