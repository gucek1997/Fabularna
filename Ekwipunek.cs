using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ekwipunek : MonoBehaviour
{

    public List<Przedmiot> ListaNaszychPrzedmiotow = new List<Przedmiot>();

    bool czyWyswietlicEkwipunek;

    public Przedmiot przeciaganyPrzedmiot;
    bool czyPrzeciagamyPrzedmiot;

    public GUISkin skin;

    int iloscX;
    int iloscY;

    void Start()
    {
        czyWyswietlicEkwipunek = false;
        iloscX = 3;
        iloscY = 3;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            czyWyswietlicEkwipunek = !czyWyswietlicEkwipunek;
        }



    }

    void OnGUI()
    {
        if (czyWyswietlicEkwipunek == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            PokazEq();



        }
        else
        {

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }

        if (czyPrzeciagamyPrzedmiot == true)
        {
            GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 50, 50), przeciaganyPrzedmiot.ikonaPrzedmiotu);
        }


    }


    void PokazEq()
    {
        int i = 0;

        for (int x = 0; x < iloscX; x++)
        {
            for (int y = 0; y < iloscY; y++)
            {
                Rect polozenieslotow = new Rect(Screen.width * 0.15f + (x * Screen.width * 0.075f), Screen.height * 0.25f + (y * Screen.height * 0.13f), Screen.width * 0.07f, Screen.height * 0.12f);
                GUI.Box(polozenieslotow, "", skin.GetStyle("SlotEkwipunku"));
                if (ListaNaszychPrzedmiotow[i].id != 0)
                {
                    GUI.DrawTexture(polozenieslotow, ListaNaszychPrzedmiotow[i].ikonaPrzedmiotu);

                }
                // Przeciaganie przedmiotow
                if (polozenieslotow.Contains(Event.current.mousePosition) && Event.current.type == EventType.MouseDrag && czyPrzeciagamyPrzedmiot == false)
                {
                    przeciaganyPrzedmiot = ListaNaszychPrzedmiotow[i];
                    ListaNaszychPrzedmiotow[i] = new Przedmiot();
                    czyPrzeciagamyPrzedmiot = true;
                }

                if (polozenieslotow.Contains(Event.current.mousePosition) && Event.current.type == EventType.MouseUp && ListaNaszychPrzedmiotow[i].id == 0)
                {
                    ListaNaszychPrzedmiotow[i] = przeciaganyPrzedmiot;
                    czyPrzeciagamyPrzedmiot = false;

                }




                i++;
            }
        }
    }






}
