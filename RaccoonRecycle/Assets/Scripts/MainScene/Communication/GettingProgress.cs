using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingProgress : MonoBehaviour
{
    DatabaseCommunication dataScript; //az adatb�zisb�l megkapott adatokat kezel� script

    public GameObject Unlock_PB; //petbottle felold�s�t int�z� ablak
    public GameObject Upgrade_PB; //petbottle fejleszt�seit tartalmaz� ablak

    public GameObject Unlock_BX; //kartondoboz felold�s�t int�z� ablak
    public GameObject Upgrade_BX; //kartondoboz fejleszt�seit tartalmaz� ablak

    public GameObject Unlock_GL; //�veg felold�s�t int�z� ablak
    public GameObject Upgrade_GL; //�veg fejleszt�seit tartalmaz� ablak

    public GameObject Unlock_BY; //elem felold�s�t int�z� ablak
    public GameObject Upgrade_BY; //elem fejleszt�seit tartalmaz� ablak

    public bool PB_Unlocked;
    public bool BX_Unlocked;
    public bool GL_Unlocked;
    public bool BTY_Unlocked;

    public int progress;

    // Start is called before the first frame update
    void Start()
    {
        dataScript = GameObject.FindGameObjectWithTag("DatabaseCommunication").GetComponent<DatabaseCommunication>(); //a scriptet kiveszi az adott objektumb�l mint komponense
    }

    // Update is called once per frame
    void Update()
    {
        ProgressUpdate();
    }

    public void ProgressUpdate()
    {

        if (!Unlock_PB.active)
        {
            if (!Unlock_BX.active)
            {
                if (!Unlock_GL.active)
                {
                    if (!Unlock_BY.active)
                    {
                        progress = 4;
                    }
                    else
                    {
                        progress = 3;
                    }
                }
                else
                {
                    progress = 2;
                }
            }
            else
            {
                progress = 1;
            }
        }
        else
        {
            progress = 0;
        }
        
    }

    public int sendProgress()
    {
        return progress;
    }
}
