using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokaz_pytanie_1 : MonoBehaviour
{
    public Canvas Pytanie;
    int dana;
    int licznik = 1;





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
