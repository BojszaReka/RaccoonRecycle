using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolderBehavior : MonoBehaviour
{
    public GameObject Unlock_PB; //petbottle felold�s�t int�z� ablak
    public GameObject Upgrade_PB; //petbottle fejleszt�seit tartalmaz� ablak

    public GameObject Unlock_BX; //kartondoboz felold�s�t int�z� ablak
    public GameObject Upgrade_BX; //kartondoboz fejleszt�seit tartalmaz� ablak

    public GameObject Unlock_GL; //�veg felold�s�t int�z� ablak
    public GameObject Upgrade_GL; //�veg fejleszt�seit tartalmaz� ablak

    public GameObject Unlock_BY; //elem felold�s�t int�z� ablak
    public GameObject Upgrade_BY; //elem fejleszt�seit tartalmaz� ablak



    void Start() //a j�t�k elindul�sakor lefut
    {
        defaultStart(); //lefut a defaultstart met�dus
        
        petbottleUnlock();
        boxUnlock();
    }

    void Update() //k�pfriss�t�senk�nt lefut
    {
        
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

        /*
        GameObject.Find("lvl1_PetBottle").SetActive(false);
        GameObject.Find("lvl2_Box").SetActive(false);
        GameObject.Find("lvl3_Glass").SetActive(false);
        GameObject.Find("lvl4_Battery").SetActive(false);
        */
    }

    void petbottleUnlock() //met�dus, megh�v�s�val minden sz�ks�ges elem l�that�s�ga v�ltozik - petpalack felold�sa
    {
        Unlock_PB.SetActive(false);
        Upgrade_PB.SetActive(true);

        Unlock_BX.SetActive(true);

        GameObject.Find("lvl1_PetBottle").SetActive(true);
    }

    void boxUnlock() //met�dus, megh�v�s�val minden sz�ks�ges elem l�that�s�ga v�ltozik - kartondoboz felold�sa
    {
        Unlock_BX.SetActive(false);
        Upgrade_BX.SetActive(true);

        Unlock_GL.SetActive(true);

        GameObject.Find("lvl2_Box").SetActive(true);
        GameObject.Find("TrashCan_Main").SetActive(false);
    }

    void glassUnlock() //met�dus, megh�v�s�val minden sz�ks�ges elem l�that�s�ga v�ltozik - �veg felold�sa
    {
        Unlock_GL.SetActive(false);
        Upgrade_GL.SetActive(true);

        Unlock_BY.SetActive(true);

        GameObject.Find("lvl3_Glass").SetActive(true);
        GameObject.Find("TrashCan_Main2").SetActive(false);
    }

    void batteryUnlock() //met�dus, megh�v�s�val minden sz�ks�ges elem l�that�s�ga v�ltozik - elem felold�sa
    {
        Unlock_BY.SetActive(false);
        Upgrade_BY.SetActive(true);

        GameObject.Find("lvl4_Battery").SetActive(true);
        GameObject.Find("TrashCan_Main3").SetActive(false);
    }
}
