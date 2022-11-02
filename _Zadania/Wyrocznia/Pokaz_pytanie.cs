using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokaz_pytanie : MonoBehaviour
{
    public Canvas Pytanie;
    int dana;
    int licznik = 0;



    void OnTriggerEnter(Collider Quiz)
    {
        
         
        if (Quiz.CompareTag("Gracz"))
        {
            dana = FindObjectOfType<ParseXML>().wartosc;
            if (dana == licznik)
            {

             
                Pytanie.enabled = true;

            }
        }
    }


  


}
