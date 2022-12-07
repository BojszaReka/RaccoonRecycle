using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statistics : MonoBehaviour
{
    DatabaseCommunication dataScript; //az adatb�zisb�l megkapott adatokat kezel� script
    Selling sellingScript; //a currency-t kezel� script

    //a megjeln�t�sre haszn�lt k�l�nb�z� mez�k
    public Text text_Nc; //normalCurrency
    public Text text_Pc; //prestigeCurrency
    public Text text_Te; //total earnings -> j�t�k kezdete, vagy utols� prestige �ta

    public Text text_PBValue; //petpalack �rt�ke
    public Text text_PBEarnings; //petpalackkal szerzett �sszbev�tel

    public Text text_BXValue; //box �rt�ke
    public Text text_BXEarnings; //boxxal szerzett �sszbev�tel

    public Text text_GLValue; //�veg �rt�ke
    public Text text_GLEarnings; //�veggel szerzett �sszbev�tel

    public Text text_BYValue; //battery �rt�ke
    public Text text_BYEarnings; //batteryvel szerzett �sszbev�tel

    float multiplier; //szorz�

    // Start is called before the first frame update
    void Start()
    {
        dataScript = GameObject.FindGameObjectWithTag("DatabaseCommunication").GetComponent<DatabaseCommunication>(); //a scriptet kiveszi az adott objektumb�l mint komponense
        sellingScript = GameObject.FindGameObjectWithTag("SellingScript").GetComponent<Selling>(); //a scriptet kiveszi az adott objektumb�l mint komponense

        multiplier = 1.07f; //szorz� alap �rt�k�t be�ll�tja 7%-ps n�veked�s
    }

    // Update is called once per frame
    void Update()
    {
        displayData(); //elind�tja a displaydata-t
    }

    void displayData() //feladata megjelen�teni az adatokat
    {
        //a sz�vegmez�k �rt�kei a datascript-b�l kivett adatok, melyeket el�tte megjelen�thet� form�ba alak�tunk
        text_Nc.text = sellingScript.convertCurrencyToDisplay(dataScript.normalCurrency.ToString());
        text_Pc.text = sellingScript.convertCurrencyToDisplay(dataScript.prestigeCurrency.ToString());
        text_Te.text = sellingScript.convertCurrencyToDisplay(dataScript.totalEarnings.ToString());

        text_PBValue.text = sellingScript.convertCurrencyToDisplay((25 * Mathf.Pow(multiplier, dataScript.PB_valueLvl)).ToString());
        text_PBEarnings.text = sellingScript.convertCurrencyToDisplay(dataScript.PB_soldAmount.ToString());

        text_BXValue.text = sellingScript.convertCurrencyToDisplay((50 * Mathf.Pow(multiplier, dataScript.BX_valueLvl)).ToString());
        text_BXEarnings.text = sellingScript.convertCurrencyToDisplay(dataScript.BX_soldAmount.ToString());

        text_GLValue.text = sellingScript.convertCurrencyToDisplay((100 * Mathf.Pow(multiplier, dataScript.GL_valueLvl)).ToString());
        text_GLEarnings.text = sellingScript.convertCurrencyToDisplay(dataScript.GL_soldAmount.ToString());

        text_BYValue.text = sellingScript.convertCurrencyToDisplay((200 * Mathf.Pow(multiplier, dataScript.BY_valueLvl)).ToString());
        text_BYEarnings.text = sellingScript.convertCurrencyToDisplay(dataScript.BY_soldAmount.ToString());
    }
}
