using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog_Drzewo : MonoBehaviour
{

    public bool DialogAktywowany = false;
    public Canvas Kanwas;
    public int LiczbaZdan;
    public int AktZdanie = 1;
    public Text MiejsceZdan;

    public string Zdanie1;
    public string Zdanie2;
    public string Zdanie3;
    public string Zdanie4;
    public string Zdanie5;



    void Start()
    {
        Kanwas.enabled = false;
    }

    void Update()
    {
        if (DialogAktywowany == true)
        {
            Kanwas.enabled = true;
            if (Input.GetKeyDown(KeyCode.F))
            {
                AktZdanie += 1;
            }
            if (AktZdanie == 1)
            {
                MiejsceZdan.text = Zdanie1.ToString();
            }
            if (AktZdanie == 2)
            {
                MiejsceZdan.text = Zdanie2.ToString();
            }
            if (AktZdanie == 3)
            {
                MiejsceZdan.text = Zdanie3.ToString();
            }
            if (AktZdanie == 4)
            {
                MiejsceZdan.text = Zdanie4.ToString();
            }
            if (AktZdanie == 5)
            {
                MiejsceZdan.text = Zdanie5.ToString();
            }
            if (AktZdanie > LiczbaZdan)
            {
                DialogAktywowany = false;

                Kanwas.enabled = false;
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Gracz")
        {

            DialogAktywowany = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Gracz")
        {

            DialogAktywowany = false;
        }
    }




}
