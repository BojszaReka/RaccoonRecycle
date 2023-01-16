using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Properties : MonoBehaviour
{
    DatabaseCommunication dataScript; //az adatb�zisb�l megkapott adatokat kezel� script

    //alap �rt�kei a bizonyos tulajdons�goknak
    float defValue; //min�l nagyobb ann�l t�bbet �rt
    float defSpeed; //min�l nagyobb ann�l gyorsabb
    float defFrequency; //min�l kisebb ann�l gyorsabb

    int valueLvl; //�rt�k szintje
    int speedLvl; //gyorsas�g szintje
    int frequencylvl; //gyakoris�g szintje

    float multiplierPos; //pozit�v szorz�
    float multiplierNeg; //negat�v szorz�


    // Start is called before the first frame update
    void Start()
    {
        dataScript = GameObject.FindGameObjectWithTag("DatabaseCommunication").GetComponent<DatabaseCommunication>(); //a scriptet kiveszi az adott objektumb�l mint komponense

        //alap �rt�k megad�sa a k�vetkez� v�ltoz�knak
        multiplierPos = 1.02f; //2%-os n�veked�s
        multiplierNeg = 0.98f; //2%-os cs�kken�s

        defProperties(); //alap �rt�ket hat�roz meg az elemnek, amin van

        
    }

    // Update is called once per frame
    void Update()
    {
        getLevels(); //elk�ri a szintjeit a k�l�nb�z� tulajdons�goknak folyamatos, h�tha k�zben valamit fejlesztettek
    }

    public void defProperties() //megadja a tulajdons�gok alap�rtelmezett �rt�k�t
    {
        if (this.gameObject.tag == "PetBottle") //ha az objektum petbottle tag-gel rendelkezik
        {
            
            //alap �rt�keket ad
            
            defSpeed = 200; 
            defValue = 25;
            defFrequency = 2;
        }
        if (gameObject.tag == "Box") //ha az objektum box tag-gel rendelkezik
        {
            //alap �rt�keket ad
            defSpeed = 100;
            defValue = 50;
            defFrequency = 3;
        }
        if (gameObject.tag == "Glass") //ha az objektum glass tag-gel rendelkezik
        {
            //alap �rt�keket ad
            defSpeed = 90;
            defValue = 100;
            defFrequency = 4;
        }
        if (gameObject.tag == "Battery") //ha az objektum battery tag-gel rendelkezik
        {
            //alap �rt�keket ad
            defSpeed = 80;
            defValue = 200;
            defFrequency = 6;
        }
    }

    void getLevels() //adatb�zisb�l elk�rt a v�ltoz�k �rt�k�t be�ll�tja
    {
        if (gameObject.tag == "PetBottle") //ha az objektum petbottle tag-gel rendelkezik
        {
            //a v�ltoz�k �rt�ke a hozz� tartoz� adat lesz
            speedLvl = dataScript.PB_speedLvl;
            valueLvl = dataScript.PB_valueLvl;
            frequencylvl = dataScript.PB_frequencyLvl;
        }
        if (gameObject.tag == "Box") //ha az objektum box tag-gel rendelkezik
        {
            //a v�ltoz�k �rt�ke a hozz� tartoz� adat lesz
            speedLvl = dataScript.BX_speedLvl;
            valueLvl = dataScript.BX_valueLvl;
            frequencylvl = dataScript.BX_frequencyLvl;
        }
        if (gameObject.tag == "Glass") //ha az objektum glass tag-gel rendelkezik
        {
            //a v�ltoz�k �rt�ke a hozz� tartoz� adat lesz
            speedLvl = dataScript.GL_speedLvl;
            valueLvl = dataScript.GL_valueLvl;
            frequencylvl = dataScript.GL_frequencyLvl;
        }
        if (gameObject.tag == "Battery") //ha az objektum battery tag-gel rendelkezik
        {
            //a v�ltoz�k �rt�ke a hozz� tartoz� adat lesz
            speedLvl = dataScript.BY_speedLvl;
            valueLvl = dataScript.BY_valueLvl;
            frequencylvl = dataScript.BY_frequencyLvl;
        }
    }

    public float value() //visszaadja a t�nyleges �rt�ket
    {
        return defValue * Mathf.Pow(multiplierPos, valueLvl); //alap�rt�k * szorz� ^ szint k�plet �rt�k�t visszaadja
    }

    public float valueDef() //visszaadja a t�nyleges �rt�ket
    {
        return defValue; //alap�rt�k
    }

    public float speed() //visszaadja a t�nyleges sepess�g�t
    {
        return defSpeed * Mathf.Pow(multiplierPos, speedLvl); //alap�rt�k * szorz� ^ szint k�plet �rt�k�t visszaadja
    }

    public float frequency() //visszaadja a t�nyleges l�trehoz�s�nak gyakoris�g�t
    {
        return defFrequency * Mathf.Pow(multiplierNeg, frequencylvl); //alap�rt�k * szorz� ^ szint k�plet �rt�k�t visszaadja
    }

}
