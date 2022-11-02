using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokaz_pytanie_2 : MonoBehaviour
{
    public Canvas Pytanie;
    int dana;
    int licznik = 2;

    void OnTriggerEnter(Collider Quiz)
    {
        if (Quiz.CompareTag("Gracz"))
        {
            dana = FindObjectOfType<ParseXML>().wartosc;

            if (dana == licznik)
            {
           
                Pytanie.enabled = true;

                GameObject[] Mury = GameObject.FindGameObjectsWithTag("Mur");

                foreach (GameObject Mur in Mury)
                {
                    GameObject.Destroy(Mur);
                }

            }

        }
    }







}
