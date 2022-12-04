using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    //sz�ks�ges scriptek
    Selling sellingScript;
    Properties propertiesScript;
    DatabaseCommunication dataScript;

    float speed; //sebess�ge az objektumnak
    Rigidbody2D rb; //fizik�val rendelkez� objektum v�ltoz�


    void Start() //indul�skor lefut
    {
        rb = GetComponent<Rigidbody2D>(); //rb-t deklar�ljuk mint a jelenlegi fizik�val rendelkez� objektum
        sellingScript = GameObject.FindGameObjectWithTag("SellingScript").GetComponent<Selling>();
        dataScript = GameObject.FindGameObjectWithTag("DatabaseCommunication").GetComponent<DatabaseCommunication>();
    }

    void OnTriggerEnter2D(Collider2D other) //akkor fut le, amikor a szem�t objektum �tk�zik valamivel
    {
        propertiesScript = gameObject.GetComponent<Properties>();
        speed = propertiesScript.speed();
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

            switch (gameObject.tag)
            {
                case "PetBottle":
                    dataScript.pbEarningsIncrease(sellingScript.defaultValue);
                    break;
                case "Box":
                    dataScript.bxEarningsIncrease(sellingScript.defaultValue);
                    break;
                case "Glass":
                    dataScript.glEarningsIncrease(sellingScript.defaultValue);
                    break;
                case "Battery":
                    dataScript.byEarningsIncrease(sellingScript.defaultValue);
                    break;
            }

            Destroy(gameObject);
        }

        if(other.gameObject.tag == "Seller_PB" || other.gameObject.tag == "Seller_BX" || other.gameObject.tag == "Seller_GL" || other.gameObject.tag == "Seller_BY")
        {
            sellingScript.soldTrashType(propertiesScript.value());
            switch (gameObject.tag)
            {
                case "PetBottle":
                    dataScript.pbEarningsIncrease(propertiesScript.value());
                    break;
                case "Box":
                    dataScript.bxEarningsIncrease(propertiesScript.value());
                    break;
                case "Glass":
                    dataScript.glEarningsIncrease(propertiesScript.value());
                    break;
                case "Battery":
                    dataScript.byEarningsIncrease(propertiesScript.value());
                    break;
            }

            Destroy(gameObject);
        }
    }
}
