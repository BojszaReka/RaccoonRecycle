using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolderBehavior : MonoBehaviour
{
    DatabaseCommunication dataScript;

    public GameObject Unlock_PB; //petbottle felold�s�t int�z� ablak
    public GameObject Upgrade_PB; //petbottle fejleszt�seit tartalmaz� ablak
    public GameObject Conveyor_PB; //petbottle-hoz tartoz� fut�szalagelemek

    public GameObject Unlock_BX; //kartondoboz felold�s�t int�z� ablak
    public GameObject Upgrade_BX; //kartondoboz fejleszt�seit tartalmaz� ablak
    public GameObject Conveyor_BX; //kartondobozhoz tartoz� fut�szalagelemek

    public GameObject Unlock_GL; //�veg felold�s�t int�z� ablak
    public GameObject Upgrade_GL; //�veg fejleszt�seit tartalmaz� ablak
    public GameObject Conveyor_GL; //�veghez tartoz� fut�szalagelemek

    public GameObject Unlock_BY; //elem felold�s�t int�z� ablak
    public GameObject Upgrade_BY; //elem fejleszt�seit tartalmaz� ablak
    public GameObject Conveyor_BY; //elemhez tartoz� fut�szalagelemek

    //alap kuk�k objectumai
    public GameObject DefSeller1;
    public GameObject DefSeller2;
    public GameObject DefSeller3;
    public GameObject DefSeller4;

    //jelzi, hogy fel van-e oldva a bizonyos elem, funkci�i a ment�skor -> lek�r�s �s k�ld�s,  fut�skor -> kezdedti bet�lt�s
    bool PBUnlocked;
    bool BXUnlocked;
    bool GLUnlocked;
    bool BYUnlocked;

    void Start() //a j�t�k elindul�sakor lefut
    {
        dataScript = GameObject.FindGameObjectWithTag("DatabaseCommunication").GetComponent<DatabaseCommunication>();

        defaultStart();
        getData();
        loadedStart();
    }

    void Update() //k�pfriss�t�senk�nt lefut
    {
        
    }

    void getData() //met�dus, lek�ri az adatokat a sz�ks�ges v�ltoz�kba
    {
        //tervezett m�k�d�s: megpr�b�l megszerezni egy v�laszt, ha nem, alap �rt�ket �ll�t
        //alap �rt�k: minden false
        
        //ideiglenes �rt�k�ll�t�s
        PBUnlocked = dataScript.PB_Unlocked;
        BXUnlocked = dataScript.BX_Unlocked;
        GLUnlocked = dataScript.GL_Unlocked;
        BYUnlocked = dataScript.BY_Unlocked;
    }

    void defaultStart() //alap�rtelmezett ind�t�si fel�ll�s (mikor 0.r�l kezd)
    {
        //csak a petpalack felold�s�hoz sz�ks�ges ablak akt�v minden m�s nem akat�v

        Unlock_PB.SetActive(true);

        Unlock_BX.SetActive(false);
        Unlock_GL.SetActive(false);
        Unlock_BY.SetActive(false);

        Upgrade_PB.SetActive(false);
        Upgrade_BX.SetActive(false);
        Upgrade_GL.SetActive(false);
        Upgrade_BY.SetActive(false);

        
        Conveyor_PB.SetActive(false);
        Conveyor_BX.SetActive(false);
        Conveyor_GL.SetActive(false);
        Conveyor_BY.SetActive(false);
        
    }
    
    void loadedStart() //megh�v�s�val egy bizonyos ment�s �ll�s�t t�lti be
    {
        if (PBUnlocked) petbottleUnlock(); //ha fel van oldva a petbottle akkor megh�vja a met�dust
        if (BXUnlocked) boxUnlock(); //ha fel van oldva a doboz akkor megh�vja a met�dust
        if (GLUnlocked) glassUnlock(); //ha fel van oldva az �veg akkor megh�vja a met�dust
        if (BYUnlocked) batteryUnlock(); //ha fel van oldva az elem akkor megh�vja a met�dust
    }

    public void petbottleUnlock() //met�dus, megh�v�s�val minden sz�ks�ges elem l�that�s�ga v�ltozik - petpalack felold�sa
    {
        Unlock_PB.SetActive(false);
        Upgrade_PB.SetActive(true);

        Unlock_BX.SetActive(true);

        Conveyor_PB.SetActive(true);

        PBUnlocked = true;
    }

    public void boxUnlock() //met�dus, megh�v�s�val minden sz�ks�ges elem l�that�s�ga v�ltozik - kartondoboz felold�sa
    {
        Unlock_BX.SetActive(false);
        Upgrade_BX.SetActive(true);

        Unlock_GL.SetActive(true);

        Conveyor_BX.SetActive(true);
        DefSeller1.SetActive(false);

        BXUnlocked = true;
    }

    public void glassUnlock() //met�dus, megh�v�s�val minden sz�ks�ges elem l�that�s�ga v�ltozik - �veg felold�sa
    {
        Unlock_GL.SetActive(false);
        Upgrade_GL.SetActive(true);

        Unlock_BY.SetActive(true);

        Conveyor_GL.SetActive(true);
        DefSeller2.SetActive(false);

        GLUnlocked = true;
    }

    public void batteryUnlock() //met�dus, megh�v�s�val minden sz�ks�ges elem l�that�s�ga v�ltozik - elem felold�sa
    {
        Unlock_BY.SetActive(false);
        Upgrade_BY.SetActive(true);

        Conveyor_BY.SetActive(true);
        DefSeller3.SetActive(false);

        BYUnlocked = true;
    }
}