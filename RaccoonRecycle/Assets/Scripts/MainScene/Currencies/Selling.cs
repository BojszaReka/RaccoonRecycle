using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selling : MonoBehaviour
{
    DatabaseCommunication dataScript;
    Properties propertiesScript;

    float normalCurrency; //az alap currenciet tartalmaz� v�ltoz�
    float prestigeCurrency; //a prestige currenciet tartalmaz� v�ltoz�
    float totalearnings; //a j�t�k kezdete vagy utols� prestige �ta szerzett normal currency

    public Text ncDisplay; //a megjelen�t�sre haszn�lt mez�t tartalmaz� v�ltoz�
    public Text pcDisplay; //megjelen�t�sre haszn�lt mez�t tartalmaz� v�ltoz�

    //egyenl�re nem fixek, tesztel�shez:
    float defaultValue; //a szemetek alap�rtelmezett �rt�ke
    float multiplier; //a szemetek �rt�k�hez haszn�lt szorz�


    void Start() //a j�t�k elindul�s�n�l lefut
    {
        dataScript = GameObject.FindGameObjectWithTag("DatabaseCommunication").GetComponent<DatabaseCommunication>();

        defaultValue = 10; //alap�rtelmezett �rt�k be�ll�t�sa
        multiplier = 1.05f;
        getCurrencieValues(); //megh�vja a met�dust
    }

    void Update() //minden k�pfriss�t�sn�l lefut
    {
        displayCurrency(); //megh�vja a met�dust
    }

    void getCurrencieValues() //met�dus, feladata megszerezni a normal es prestige currency elmentett mennyis�g�t
    {
        normalCurrency = dataScript.normalCurrency;
        prestigeCurrency = dataScript.prestigeCurrency;
        totalearnings = dataScript.totalEarnings;
    }

    void addCurrency(float n) //met�dus, n�veli a currencyk mennyis�g�t
    {
        normalCurrency += n; //a normalcurrency mennyis�g�t n�veli az n �rt�k�vel
        totalearnings += n; //a totalearnigs mennyis�g�t n�veli az n �rt�k�vel
    }

    void displayCurrency() //met�dus, feladata a currencyk mennyis�g�nek megjelen�t�se bizonyos objektumokon kereszt�l
    {
        ncDisplay.text = convertCurrencyToDisplay(normalCurrency.ToString()); //ncdisplay �t�k�t az �talak�tottt normalcurrency-v� �ll�tja
        pcDisplay.text = convertCurrencyToDisplay(prestigeCurrency.ToString()); //pcdisplay �t�k�t az �talak�tottt prestigecurrency-v� �ll�tja
    }


    //public methods: 

    public void normalSelling() //met�dus, m�s scriptek �s objektumok �ltal is megh�vhat�, mely a default seller �ltal t�rt�n� elad�skor fut le
    {
        addCurrency(defaultValue); //a szemetek alap �rt�k�t �tadva megh�vjuk az addCurrency-t
    }

    public void soldTrashType(float amount) //petpalack, b�rmilyen fix szem�t elad�sakor h�v�dik, majd fut le, n�velli a normalcurrency �rt�k�t
    {
        addCurrency(amount);
    }

    public bool isEnoughNormalCurrency(float n) //met�dus, megh�v�s�val igaz v hamis �rt�ket ad vissza arr�l, hogy van-e ell�g normalcurrency a fejleszt�sre
    {
        if(normalCurrency > n || normalCurrency == n) //ha t�bb vagy egyenl�
        {
            return true; //igaz
        }
        return false; //hamis
    }

    public bool isEnoughPrestigeCurrency(float n) //met�dus, megh�v�s�val igaz v hamis �rt�ket ad vissza arr�l, hogy van-e ell�g prestigecurrency a fejleszt�sre
    {
        if (prestigeCurrency > n || prestigeCurrency == n) //ha t�bb vagy egyenl�
        {
            return true; //igaz
        }
        return false; //hamis
    }

    public string convertCurrencyToDisplay(string nc) //met�dus, megh�v�s�val megjelen�thet� �llapotba lehet alak�tani a currency-k mennyis�g�t, k�r egy string nc-t, mely a birtokolt currency sz�vegg� alak�tva
    {
        string[] endings = { "", "", "K", "M", "B", "T", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "N", "O", "P", "Q", "R", "S" }; //t�mb, tartalmazza a r�vid�t�seket, melyek utalnak a birtokolt p�nzmennyis�g �rt�k�re
        if (nc.Split(",")[0].Length > 4) //tizedesvessz�n�l elv�lasztva a 0. fele ha nagyobb mint 4
        {
            switch (nc.Split(",")[0].Length % 3) //az els� f�l hossz�nak h�rommal osztva adott marad�ka alapj�n
            {
                case 0: //ha a marad�k 0
                    return nc.Substring(0, 3) + "." + nc.Substring(3, 1) + " " + endings[(nc.Split(",")[0].Length) / 3]; //visszaadott form�tum
                case 1: //ha a marad�k 1
                    return nc.Substring(0, 1) + "." + nc.Substring(1, 2) + " " + endings[(nc.Split(",")[0].Length + 2) / 3]; //visszaadott form�tum
                case 2: //ha a marad�k 2
                    return nc.Substring(0, 2) + "." + nc.Substring(2, 2) + " " + endings[(nc.Split(",")[0].Length + 2) / 3]; //visszaadott form�tum
                default: return nc; //alap�rtelmezett visszat�r�si �rt�k
            }
        }
        else //tizedesvessz�n�l elv�lasztva a 0. fele ha nem nagyobb mint 4
        {
            return nc.Split(",")[0]; //visszadaja az elv�lasztott els� fel�t
        }
    }

    public void boughtUpgradeNormal(float n) //met�dus, megh�vva �s �tadva neki az n-t, levonja az n mennyis�g�t a normalcurrency-b�l
    {
        normalCurrency -= n; //normalcurrency-b�l kivonja az n �rt�k�t
    }

    public void boughtUpgradePrestige(float n) //met�dus, megh�vva �s �tadva neki az n-t, levonja az n mennyis�g�t a prestigecurrency-b�l
    {
        prestigeCurrency -= n; //pretigecurrency-b�l kivonja az n �rt�k�t
    }
}
