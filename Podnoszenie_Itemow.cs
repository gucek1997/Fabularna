using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Podnoszenie_Itemow : MonoBehaviour
{
    public GameObject DoPodniesienia;

    bool podnoszenie;

    public Ekwipunek ekwipunek;


    int IdPrzedmiotu;

    public GUISkin skin;

    void Start()
    {

        BazaDanych_Eq.Listaprzedmiotow.Add(new Przedmiot(0, "Nic", "Nic"));
        BazaDanych_Eq.Listaprzedmiotow.Add(new Przedmiot(1, "Drewno", "Drewno na opal"));
        BazaDanych_Eq.Listaprzedmiotow.Add(new Przedmiot(2, "Kamien", "Fragment Skaly"));

    }

  
  
        void Update()
        {

        if (podnoszenie == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {

                IdPrzedmiotu = DoPodniesienia.GetComponent<PrzedmiotPodniesienie>().id;

                
                /*
                if (DoPodniesienia != null)
                {
                    ekwipunek.ListaNaszychPrzedmiotow[0] = BazaDanych_Eq.Listaprzedmiotow[IdPrzedmiotu];
                    Destroy(DoPodniesienia);
                    DoPodniesienia = null;
                }
                */


                                  for (int i = 0; i < ekwipunek.ListaNaszychPrzedmiotow.Count; i++)
                                    {
                                        if (ekwipunek.ListaNaszychPrzedmiotow[i].id == 0 && DoPodniesienia != null)
                                        {
                                            ekwipunek.ListaNaszychPrzedmiotow[i] = BazaDanych_Eq.Listaprzedmiotow [IdPrzedmiotu];
                                            Destroy(DoPodniesienia);
                                            DoPodniesienia = null;
                                        }
                                    }



            }
            }   

        }

        void OnTriggerEnter(Collider col)
        {
            if (col.tag == "Przedmiot")
            {
                DoPodniesienia = col.gameObject;
                podnoszenie = true;
            }
        }

        void OnTriggerExit(Collider col)
        {
            if (col.tag == "Przedmiot")
            {
                DoPodniesienia = null;
                podnoszenie = false;
            }
        }


    void OnGUI()
    {
        if (DoPodniesienia == true)
        {
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 200, 200), "Naciśnij Q aby podnieść przedmiot", skin.GetStyle("Wejscie"));
        }
    }



}
