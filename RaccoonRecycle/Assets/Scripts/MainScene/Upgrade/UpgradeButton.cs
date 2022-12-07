using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour //kezel mimndent, ami az upgrade gombok lenyom�sakor t�rt�nik
{
    Selling sellingScript; //a currency-t kezel� script
    DatabaseCommunication dataScript; //az adatb�zisb�l megkapott adatokat kezel� script

    float multiplier; //�rt�ksz�m�t�sokhoz a szorz�
    int trashType; //a szem�t t�pusa 1-petbottle, 2-box, 3-glass, 4-battery

    int ValueCostLvl; //�rt�k �r�nak szintje
    int SpeedCostLvl; //sebess�g �r�nak szintje
    int FrequencyCostLvl; //gyakoris�g �r�nak szintje

    float ValueDefCost; //�rt�k alap �ra
    float SpeedDefCost; //gyorsas�g alap �ra
    float FrequencyDefCost; //gyakoris�g alap �ra

    float ValueCost; //�rt�k �ra - sz�m�tott �rt�k
    float SpeedCost; //gyorsas�g �ra - sz�m�tott �rt�k
    float FrequencyCost; //gyakoris�g �ra - sz�m�tott �rt�k

    public Button button_Value; //�rt�k fejleszt�s�hez tartoz� gmb
    public Button button_Speed; //gyorsas�g fejleszt�s�hez tartoz� gomb
    public Button button_Frequency; //gyakoris�g fejleszt�s�hez tartoz� gomb

    public Text text_Value; //�rt�k �r�nak megjelen�t�s�hez haszn�lt sz�veg
    public Text text_Speed; //gyorsas�g megjelen�t�s�hez haszn�lt sz�veg
    public Text text_Frequency; //gyakoris�g megjelen�t�s�hez haszn�lt sz�veg


    // Start is called before the first frame update
    void Start()
    {
        sellingScript = GameObject.FindGameObjectWithTag("SellingScript").GetComponent<Selling>(); //a scriptet kiveszi az adott objektumb�l mint komponense
        dataScript = GameObject.FindGameObjectWithTag("DatabaseCommunication").GetComponent<DatabaseCommunication>(); //a scriptet kiveszi az adott objektumb�l mint komponense

        //az aktu�lis objektum tag-je alapj�n(melyen a script van), meghat�rozza a trashtype �rt�k�t
        switch (gameObject.tag)
        {
            case "PetBottleU": trashType = 1; break;
            case "BoxU": trashType = 2; break;
            case "GlassU": trashType = 3; break;
            case "BatteryU": trashType = 4; break;
            default: trashType = 0; Debug.Log("TrashType 0!"); break; //ha a tag egyik opci�val se egyezik alap �rt�kk�nt 0-�t �ll�tunk valamint logoljuk
        }

        defaultStart(); //elind�tja a defaultstart-ot

        //a feljebb megadott gombok 'gomb' komponens�re click listener ker�l, kattint�skor a megfelel� k�d fut le
        Button btn_UV = button_Value.GetComponent<Button>();
        btn_UV.onClick.AddListener(value);

        Button btn_US = button_Speed.GetComponent<Button>();
        btn_US.onClick.AddListener(speed);

        Button btn_UF = button_Frequency.GetComponent<Button>();
        btn_UF.onClick.AddListener(frequency);
    }

    // Update is called once per frame
    void Update()
    {
        calculateCost(); //elind�tja a calculatecost-t
        displayCost(); //elind�tja a displaycast-t
        toAble(); //elind�tja a toAble-t
    }

    void defaultStart() //azon adatokat defini�lja, melyeket nem v�laszk�nt v�runk az adatb�zisb�l
    {
        multiplier = 1.07f; // szorz� �rt�ke 7%-os n�veked�s

        //trashtype �rt�k�t�l f�gg�en lesznek az tulajdons�gok alap �rai be�ll�tva
        switch (trashType) 
        {
            case 0: Debug.Log("Tag hiba"); break;
            case 1:
                ValueDefCost = 50;
                SpeedDefCost = 25;
                FrequencyDefCost = 15;
                break;
            case 2:
                ValueDefCost = 100;
                SpeedDefCost = 50;
                FrequencyDefCost = 30;
                break;
            case 3:
                ValueDefCost = 200;
                SpeedDefCost = 100;
                FrequencyDefCost = 60;
                break;
            case 4:
                ValueDefCost = 400;
                SpeedDefCost = 200;
                FrequencyDefCost = 120;
                break;
            default: Debug.Log("Default �rt�kek");
                ValueDefCost = 40;
                SpeedDefCost = 20;
                FrequencyDefCost = 10;
                break;
        }
    }

    public void getLevels()  //a szintek �rt�k�t szerzi meg a datascript-b�l
    {
        //trashtype �rt�ke alapj�n �ll�tja be a value, speed, frequency �rt�keit
        switch (trashType)
        {
            case 0: Debug.Log("Tag hiba"); break;
            case 1:
                ValueCostLvl = dataScript.PB_valueLvl;
                SpeedCostLvl = dataScript.PB_speedLvl;
                FrequencyCostLvl = dataScript.PB_frequencyLvl;
                break;
            case 2:
                ValueCostLvl = dataScript.BX_valueLvl;
                SpeedCostLvl = dataScript.BX_speedLvl;
                FrequencyCostLvl = dataScript.BX_frequencyLvl;
                break;
            case 3:
                ValueCostLvl = dataScript.GL_valueLvl;
                SpeedCostLvl = dataScript.GL_speedLvl;
                FrequencyCostLvl = dataScript.GL_frequencyLvl;
                break;
            case 4:
                ValueCostLvl = dataScript.BY_valueLvl;
                SpeedCostLvl = dataScript.BY_speedLvl;
                FrequencyCostLvl = dataScript.BY_frequencyLvl;
                break;
            default:
                Debug.Log("Default szintek");
                ValueCostLvl = 0;
                SpeedCostLvl = 0;
                FrequencyCostLvl = 0;
                break;
        }
    }

    void toAble() //feladata meghat�rozni, hogy a gomb el�rhet� legyen e
    {
        //gomb el�rhet�s�g�t �ll�tja, mely f�gg att�l, hogy van-e el�g p�nze a felold�sra
        button_Value.interactable = sellingScript.isEnoughNormalCurrency(ValueCost);
        button_Speed.interactable = sellingScript.isEnoughNormalCurrency(SpeedCost);
        button_Frequency.interactable = sellingScript.isEnoughNormalCurrency(FrequencyCost);
    }

    void calculateCost() //feldata kisz�molni a fejleszthet� tulajdons�gok �rait
    {
        //�r = alap �rt�k * szorz�^szint
        ValueCost = ValueDefCost * Mathf.Pow(multiplier, ValueCostLvl);
        SpeedCost = SpeedDefCost * Mathf.Pow(multiplier, SpeedCostLvl);
        FrequencyCost = FrequencyDefCost * Mathf.Pow(multiplier, FrequencyCostLvl);
    }

    void displayCost() // feldata megjelen�teni a kisz�molt �rakat
    {
        //az �rt�keket megjelen�thet� fom�ba �ll�tjuk, majd azt megkapja a text komponense
        text_Value.text = sellingScript.convertCurrencyToDisplay(ValueCost.ToString());
        text_Speed.text = sellingScript.convertCurrencyToDisplay(SpeedCost.ToString());
        text_Frequency.text = sellingScript.convertCurrencyToDisplay(FrequencyCost.ToString());
    }

    void value() //�rt�k gomb lenyom�sakor fut le
    {
        ValueCostLvl++; //az �r szintj�t n�veli eggyel
        sellingScript.boughtUpgradeNormal(ValueCost); //az �rat levonja a normalcurrency egyenlegb�l

        dataScript.upgrade(trashType, "value"); //datascript upgrade-j�t futtatja le, �tadva neki a trashtype-ot �s egy stringet (jelenleg: value)
    }

    void speed() //gyorsas�g gomb lenyom�sakor fut le
    {
        SpeedCostLvl++; //az �r szintj�t n�veli eggyel
        sellingScript.boughtUpgradeNormal(SpeedCost); //az �rat levonja a normalcurrency egyenlegb�l

        dataScript.upgrade(trashType, "speed"); //datascript upgrade-j�t futtatja le, �tadva neki a trashtype-ot �s egy stringet (jelenleg: speed)
    }

    void frequency()//gyakoris�g gomb lenyom�sakor fut le
    {
        FrequencyCostLvl++; //az �r szintj�t n�veli eggyel
        sellingScript.boughtUpgradeNormal(FrequencyCost); //az �rat levonja a normalcurrency egyenlegb�l

        dataScript.upgrade(trashType, "frequency"); //datascript upgrade-j�t futtatja le, �tadva neki a trashtype-ot �s egy stringet (jelenleg: frequency)
    }
}
