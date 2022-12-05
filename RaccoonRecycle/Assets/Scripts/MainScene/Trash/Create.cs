using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
    Properties propertiesScript; //tulajdons�gokat taralmaz� scripthez a v�ltoz�

    public Rigidbody2D trashPrefab; //pbulikus v�ltoz� a l�trehozni k�v�nt szem�tnek
    public GameObject parent; //publikus v�ltoz� a szem�t sz�l�objektum�hoz
    
    //ideiglenes v�ltoz�k a szem�t m�k�d�s�hez
    float frequency;
    float speed;

    private Vector2 location; //vector2 v�ltoz� egy helyzethez
    private Rigidbody2D rb; //fizik�val rendelkez� objektum v�ltoz�

    void Start() //met�dus lefut a j�t�k indul�sakor
    {
         //location v�ltoz� megkapja a Generator objektum helyzet�t adatk�nt
        propertiesScript = trashPrefab.GetComponent<Properties>(); //a tulajdons�gokat tartalmaz� script az aktu�lis trashprefab
        
        Spawn(); //megh�vja a spawn met�dust
        StartCoroutine(Flow()); //megh�vja a flow met�dust

    }

    void Update() //minden k�prissit�sn�l lefut
    {

    }

    private void Spawn() //met�dus, lefut�s�val l�trehoz szem�t objektumokat
    {
        location = GameObject.Find("Generator").transform.position;
        Rigidbody2D rb = Instantiate(trashPrefab) as Rigidbody2D; //l�trehoz egy rigidbody2d-t a trashPrefab-b�l
        propertiesScript.defProperties();
        frequency = propertiesScript.frequency();
        speed = propertiesScript.speed();
        rb.transform.position = location; // rb helyzete a generator helyzete lesz
        rb.transform.SetParent(parent.transform); //rb sz�l� objektum�t be�ll�tja
        rb.velocity = new Vector2(speed, 0); //rb mozg�sa: megindul ebbe az ir�nyba
    }
    
    IEnumerator Flow() //met�dus, lefut�s�val folyamatos a szemetek l�trehoz�sa
    {
        while (true) //v�gtelen ciklus
        {
            yield return new WaitForSeconds(frequency); //v�r annyi m�sodpercet, amennyi frequency �rt�ke
            Spawn(); //megh�vja a spawn met�dust
        }

    }
}
