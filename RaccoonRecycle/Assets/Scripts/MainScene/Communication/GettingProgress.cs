using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingProgress : MonoBehaviour
{
    DatabaseCommunication dataScript; //az adatb�zisb�l megkapott adatokat kezel� script

    public int progress;

    // Start is called before the first frame update
    void Start()
    {
        dataScript = GameObject.FindGameObjectWithTag("DatabaseCommunication").GetComponent<DatabaseCommunication>(); //a scriptet kiveszi az adott objektumb�l mint komponense
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ProgressSet(int p)
    {
        progress = p;
    }

    public int sendProgress()
    {
        return progress;
    }
}
