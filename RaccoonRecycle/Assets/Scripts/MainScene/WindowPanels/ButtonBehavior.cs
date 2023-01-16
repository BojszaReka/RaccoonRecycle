using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
    //haszn�lt scriptek v�ltoz�i
    Selling sellingScript; //a currency-t kezel� script
    HolderBehavior holderScript; //a holderek viselked�s�t kezel� script
    GettingProgress progressScript; // a feloldott halad�st jelzi vissza

    //minden szem�tfajt�hoz tartoz� gomb, felirat �s �r
    //gomb -> megnyom�s�val feloldhat� a fut�szalag, felirat -> ki�rja az �rat, cost -> megadja az �rat
    public Button button_UnlockPB;
    public Text text_UnlockPB;
    float cost_UnlockPB;

    public Button button_UnlockBX;
    public Text text_UnlockBX;
    float cost_UnlockBX;

    public Button button_UnlockGL;
    public Text text_UnlockGL;
    float cost_UnlockGL;

    public Button button_UnlockBY;
    public Text text_UnlockBY;
    float cost_UnlockBY;

    // Start is called before the first frame update
    void Start()
    {
        sellingScript = GameObject.FindGameObjectWithTag("SellingScript").GetComponent<Selling>(); //a scriptet kiveszi az adott objektumb�l mint komponense
        holderScript = GameObject.FindGameObjectWithTag("WindowBehavior").GetComponent<HolderBehavior>(); //a scriptet kiveszi az adott objektumb�l mint komponense
        progressScript = GameObject.FindGameObjectWithTag("DatabaseCommunication").GetComponent<GettingProgress>(); //a scriptet kiveszi az adott objektumb�l mint komponense

        defaultStart(); //alap�rtelmezett elindul�s

        //a feljebb megadott gombok 'gomb' komponens�re click listener ker�l, kattint�skor a megfelel� k�d fut le
        Button btn_UPB = button_UnlockPB.GetComponent<Button>();
        btn_UPB.onClick.AddListener(unlockPB);
        
        Button btn_UBX = button_UnlockBX.GetComponent<Button>();
        btn_UBX.onClick.AddListener(unlockBX);

        Button btn_UGL = button_UnlockGL.GetComponent<Button>();
        btn_UGL.onClick.AddListener(unlockGL);

        Button btn_UBY = button_UnlockBY.GetComponent<Button>();
        btn_UBY.onClick.AddListener(unlockBY);

        //a feliratok tartalm�t az �rra v�ltoztatja, mely el�tte konverzi�n esik �t
        text_UnlockPB.text = sellingScript.convertCurrencyToDisplay(cost_UnlockPB.ToString());
        text_UnlockBX.text = sellingScript.convertCurrencyToDisplay(cost_UnlockBX.ToString());
        text_UnlockGL.text = sellingScript.convertCurrencyToDisplay(cost_UnlockGL.ToString());
        text_UnlockBY.text = sellingScript.convertCurrencyToDisplay(cost_UnlockBY.ToString());
    }

    // Update is called once per frame
    void Update()
    {
       toAble(); //gombok haszn�lhat�s�ga
    }

    void defaultStart() //alap �rt�k�ll�t�s bizonyos v�ltoz�knak
    {
        cost_UnlockPB = 50;
        cost_UnlockBX = 10000;
        cost_UnlockGL = 150000;
        cost_UnlockBY = 2000000;
    }

    void toAble() //feladata meghat�rozni, hogy a gomb el�rhet� legyen e
    {
        //gomb el�rhet�s�g�t �ll�tja, mely f�gg att�l, hogy van-e el�g p�nze a felold�sra
        button_UnlockPB.interactable = sellingScript.isEnoughNormalCurrency(cost_UnlockPB);
        button_UnlockBX.interactable = sellingScript.isEnoughPrestigeCurrency(cost_UnlockBX);
        button_UnlockGL.interactable = sellingScript.isEnoughPrestigeCurrency(cost_UnlockGL);
        button_UnlockBY.interactable = sellingScript.isEnoughPrestigeCurrency(cost_UnlockBY);
    }

    void unlockPB() //petpalack felold�sa
    {
        holderScript.petbottleUnlock(); //a sz�gs�ges objektumok l�that�s�ga v�ltozik
        sellingScript.boughtUpgradeNormal(cost_UnlockPB); //a felold�s �ra levon�sra ker�l az egyenlegr�l
        progressScript.ProgressSet(1);
    }

    void unlockBX() //doboz felold�sa
    {
        holderScript.boxUnlock(); //a sz�gs�ges objektumok l�that�s�ga v�ltozik
        sellingScript.boughtUpgradePrestige(cost_UnlockBX); //a felold�s �ra levon�sra ker�l az egyenlegr�l
        progressScript.ProgressSet(2);
    }

    void unlockGL() //�veg felold�sa
    {
        holderScript.glassUnlock(); //a sz�gs�ges objektumok l�that�s�ga v�ltozik
        sellingScript.boughtUpgradePrestige(cost_UnlockGL); //a felold�s �ra levon�sra ker�l az egyenlegr�l
        progressScript.ProgressSet(3);
    }

    void unlockBY() //elem felold�sa
    {
        holderScript.batteryUnlock(); //a sz�gs�ges objektumok l�that�s�ga v�ltozik
        sellingScript.boughtUpgradePrestige(cost_UnlockBY); //a felold�s �ra levon�sra ker�l az egyenlegr�l
        progressScript.ProgressSet(4);
    }
}
