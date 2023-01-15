using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prestige : MonoBehaviour
{
    Selling sellingScript; //a currency-t kezel� script

    DatabaseCommunication dataScript; //az adatb�zisb�l megkapott adatokat kezel� script

    public Button button_PrestigeConfirm; //gomb, amire nyomva meger�s�ti sz�nd�k�t, prestigel
    public GameObject PrestigeWindow; //�zenetablak a prestige-el kapcsolatban
    public Text text_PrestigeEarnings; //sz�veg, amin kereszt�l meg lesz jelen�tve az aktu�lis prestige-gel kaphat� currency

    float prestigeEarn; //a prestige sor�n kaphat� currency

    // Start is called before the first frame update
    void Start()
    {
        sellingScript = GameObject.FindGameObjectWithTag("SellingScript").GetComponent<Selling>(); //a scriptet kiveszi az adott objektumb�l mint komponense
        dataScript = GameObject.FindGameObjectWithTag("DatabaseCommunication").GetComponent<DatabaseCommunication>(); //a scriptet kiveszi az adott objektumb�l mint komponense

    }

    // Update is called once per frame
    void Update()
    {
        prestigeEarn = sellingScript.prestigeEarning(); //megszerzi a prestige earn �rt�k�t
        text_PrestigeEarnings.text = sellingScript.convertCurrencyToDisplay(prestigeEarn.ToString()); //megjelen�ti a prestigeearnt konverzi� ut�n
    }

    public void prestige()  //feladata a kell� �rt�kek megv�ltoztat�sa
    {
        //a kell� scriptekben megt�rt�nik a feladatok lefut�sa
        sellingScript.prestigeTasks();
        dataScript.prestigeTasks();
    }
}
