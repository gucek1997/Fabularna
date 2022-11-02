using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazaDanych_Eq : MonoBehaviour
{

    public static List<Przedmiot> Listaprzedmiotow = new List<Przedmiot>();

    void Start()
    {
        Listaprzedmiotow.Add(new Przedmiot(0, "Nic", "Nic"));
        Listaprzedmiotow.Add(new Przedmiot(1, "Drewno", "Drewno na opal"));
        Listaprzedmiotow.Add(new Przedmiot(2, "Kamien", "Fragment Skaly"));

        //Debug.Log($"IdPrzedmiotuBaza ={Listaprzedmiotow.Count}");
    }


}
