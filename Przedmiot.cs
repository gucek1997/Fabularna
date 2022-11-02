using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Przedmiot 
{
    public int id;
    public string nazwa;
    public string opis;
    public Texture2D ikonaPrzedmiotu;

    public Przedmiot()
    {

    }

    public Przedmiot(int Id,string Nazwa,string Opis)
    {
        id = Id;
        nazwa = Nazwa;
        opis = Opis;
        ikonaPrzedmiotu = Resources.Load<Texture2D>("Icons/" + Nazwa);
    }


}
