using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public int speed; //ideiglenes v�ltoz�, sebess�ge az objektumnak
    Rigidbody2D rb; //fizik�val rendelkez� objektum v�ltoz�

    Selling sellingScript;

    void Start() //indul�skor lefut
    {
        rb = GetComponent<Rigidbody2D>(); //rb-t deklar�ljuk mint a jelenlegi fizik�val rendelkez� objektum
        sellingScript = GameObject.FindGameObjectWithTag("SellingScript").GetComponent<Selling>();
    }

    void OnTriggerEnter2D(Collider2D other) //akkor fut le, amikor a szem�t objektum �tk�zik valamivel
    {
        
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
            Destroy(gameObject);
        }

        if(other.gameObject.tag == "Seller_PB")
        {
            sellingScript.sellingPB();
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Seller_BX")
        {
            sellingScript.sellingBX();
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Seller_GL")
        {
            sellingScript.sellingGL();
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Seller_BY")
        {
            sellingScript.sellingBY();
            Destroy(gameObject);
        }
    }
}
