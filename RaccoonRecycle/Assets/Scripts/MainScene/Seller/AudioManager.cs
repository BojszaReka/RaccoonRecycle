using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSorce; //az sfx forr�sa
    void Start()
    {
        audioSorce = gameObject.GetComponent<AudioSource>();//elk�rj�k az audi� forr�s komponens�nket
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        audioSorce.Play();
    }
}
