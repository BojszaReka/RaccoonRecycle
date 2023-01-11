using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    //sz�ks�ges scriptek
    Selling sellingScript; //a currency-t kezel� script
    Properties propertiesScript; //tulajdons�gokat taralmaz� scripthez a v�ltoz�
    DatabaseCommunication dataScript; //az adatb�zisb�l megkapott adatokat kezel� script

    float speed; //sebess�ge az objektumnak
    Rigidbody2D rb; //fizik�val rendelkez� objektum v�ltoz�


    void Start() //indul�skor lefut
    {
        rb = GetComponent<Rigidbody2D>(); //rb-t deklar�ljuk mint a jelenlegi fizik�val rendelkez� objektum
        sellingScript = GameObject.FindGameObjectWithTag("SellingScript").GetComponent<Selling>(); //a scriptet kiveszi az adott objektumb�l mint komponense
        dataScript = GameObject.FindGameObjectWithTag("DatabaseCommunication").GetComponent<DatabaseCommunication>(); //a scriptet kiveszi az adott objektumb�l mint komponense
    }

    void OnTriggerEnter2D(Collider2D other) //akkor fut le, amikor a szem�t objektum �tk�zik valamivel
    {
        propertiesScript = gameObject.GetComponent<Properties>(); //a scriptet kiveszi az adott objektumb�l mint komponense
        speed = propertiesScript.speed(); // a gyorsas�g a propertiesScript.speed �ltal adott �rt�k
        if (other.gameObject.tag == "Collider_PB" && gameObject.tag == "PetBottle")//ha Collider_PB-vel �tk�zik PetBottle
        {
            rb.velocity = new Vector2(0, speed); //ir�nyt v�lt
        }

        if (other.gameObject.tag == "Collider_BX" && gameObject.tag == "Box") //ha Collider_BX-vel �tk�zik Box
        {
            rb.velocity = new Vector2(0, speed); //ir�nyt v�lt
        }

        if (other.gameObject.tag == "Collider_GL" && gameObject.tag == "Glass") //ha Collider_GL-vel �tk�zik Glass
        {
            rb.velocity = new Vector2(0, speed); //ir�nyt v�lt
        }

        if (other.gameObject.tag == "Collider_BY" && gameObject.tag == "Battery") //ha Collider_BY-vel �tk�zik Battery
        {
            rb.velocity = new Vector2(0, speed); //ir�nyt v�lt
        }

        if (other.gameObject.tag == "DefSeller") //ha a defseller-el �tk�zik
        {
            sellingScript.normalSelling(); //megh�vja a sellingscript normalselling met�dus�t
            dataScript.earningIncrease(gameObject.tag, sellingScript.defaultValue); //n�veli az adott szem�tt�pussal szerzett bev�telt
            Destroy(gameObject); //t�rli a szem�t objektumot
        }

        if(other.gameObject.tag == "Seller_PB" || other.gameObject.tag == "Seller_BX" || other.gameObject.tag == "Seller_GL" || other.gameObject.tag == "Seller_BY") //ha a v�gleges sellerrel �tk�zik
        { 
            sellingScript.soldTrashType(propertiesScript.value()); //megh�vja a sellingscript soldtrashtype met�dus�t �tadva neki a value tolajdons�got az aktu�lis szem�tt�l
            dataScript.earningIncrease(gameObject.tag, propertiesScript.value()); //n�veli az adott szem�tt�pussal szerzett bev�telt
            Destroy(gameObject); //t�rli a szem�t objektumot
        }
    }
}
