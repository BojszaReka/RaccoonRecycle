using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
    
    public Rigidbody2D trashPrefab; //pbulikus v�ltoz� a l�trehozni k�v�nt szem�tnek
    public GameObject parent; //publikus v�ltoz� a szem�t sz�l�objektum�hoz
    
    //ideiglenes v�ltoz�k a szem�t m�k�d�s�hez
    public int frequency;
    public int speed;
    public int value;

    private Vector2 location; //vector2 v�ltoz� egy helyzethez
    private Rigidbody2D rb; //fizik�val rendelkez� objektum v�ltoz�

    void Start() //met�dus lefut a j�t�k indul�sakor
    {
        location = GameObject.Find("Generator").transform.position; //location v�ltoz� megkapja a Generator objektum helyzet�t adatk�nt
        Spawn(); //megh�vja a spawn met�dust
        StartCoroutine(Flow()); //megh�vja a flow met�dust
    }

    void Update() //minden k�prissit�sn�l lefut
    {

    }

    private void Spawn() //met�dus, lefut�s�val l�trehoz szem�t objektumokat
    { 
        Rigidbody2D rb = Instantiate(trashPrefab) as Rigidbody2D; //l�trehoz egy rigidbody2d-t a trashPrefab-b�l
        rb.transform.position = location; // rb helyzete a generator helyzete lesz
        rb.transform.parent = parent.transform; //rb sz�l� objektum�t be�ll�tja
        rb.isKinematic = true; //nemtudom pontosan mit csin�l, de kell hogy m�k�dj�n, f�gg t�le az objektum fizik�ja
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
