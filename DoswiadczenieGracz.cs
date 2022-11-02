using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoswiadczenieGracz : MonoBehaviour
{
    public float MaxExp = 100;
    public float Exp = 0;
    public float SzerokoscOkna;
    public GUIStyle StylExp;
    public GUIStyle StylLvl;
    public int Level = 1;
    private Rect PozycjaOkna = new Rect(Screen.width / 4, Screen.height / 4, Screen.width / 2, Screen.height / 2);
    public bool czyPokazac;
    public float czas = 0;
    public int IleZostalo;
    public GameObject Gracz;
    public GameObject GraczZdr;
    public GUIStyle StylInfo;
    public GUIStyle StylPrzyciskow;
    public Camera Kamera;
    

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

        SzerokoscOkna = Screen.width / 2;
        DodawanieExp(0);

        if (Exp >= MaxExp)
        {
            Level++;
            MaxExp *= Level;
            Exp = 0;
            czas += Time.deltaTime;
            Time.timeScale = 0.0000001f;
            //  Kamera.enabled = false;
            czyPokazac = true;
            if (Level <= 10)
            {
                IleZostalo += 2;
            }
            else
            {
                IleZostalo += 1;
            }


        }

        else if (czas >0.5f)
        {
            czyPokazac = false;
            czas = 0;
        }



        if (Exp <= 0)
        {
            Exp = 0;
        }

        if (MaxExp < Exp)
        {
            MaxExp = Exp;
        }



      
    }

    void OnGUI()
    {
        GUI.Box(new Rect((Screen.width / 2) - 5, 30, SzerokoscOkna, 20), "", StylExp);
        GUI.Box(new Rect((Screen.width / 2) - 5, 30, Screen.width / 2, 20), Exp + "/" + MaxExp);
        GUI.Label(new Rect(50, 200, 100, 30), "Level : " + Level, StylLvl);

        if (czyPokazac == true)
        {
            
            PozycjaOkna = GUI.Window(0, PozycjaOkna, PokazOkno, "Level :" + Level);

        }



    }



    public void DodawanieExp(int aaa)
    {
        Exp += aaa;
        SzerokoscOkna = (Screen.width / 2) * (Exp / (float)MaxExp);

    }

    void PokazOkno(int IdOkna)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GUI.Label(new Rect(400, 50, 200, 20), "Możliwość dodania: " + IleZostalo);
        Atak at = (Atak)Gracz.GetComponent("Atak");
        Zycie zd = (Zycie)GraczZdr.GetComponent("Zycie");

        #region Atak

        GUI.Label(new Rect(10, 20, 50, 25), "Atak : ", StylInfo) ;
        GUI.Label(new Rect(70, 20, 50, 25), at.odejmowanieZdrowia + "", StylInfo);
        
        if(GUI.Button(new Rect(150,25,20,20), "+",StylPrzyciskow))
        {
            if (IleZostalo>0)
            {
                IleZostalo--;
                if(Level<=5)
                {
                    at.odejmowanieZdrowia += Level + 2;
                }
                if (Level <= 10)
                {
                    at.odejmowanieZdrowia += Level + 1;
                }
                else
                {
                    at.odejmowanieZdrowia += Level + 1;
                }

            }


        }




        #endregion

        #region Obrona
        GUI.Label(new Rect(10, 50, 50, 25), "Zdrowie: ", StylInfo);
        GUI.Label(new Rect(70, 50, 50, 25), zd.maxZycie + "", StylInfo);
        if (GUI.Button(new Rect(150,50,20,20),"+",StylPrzyciskow))
        {
            if (IleZostalo >0)
            {
                IleZostalo--;
                if (Level <= 3)
                {
                    zd.maxZycie += 10;
                }
                if (Level >3)
                {
                    zd.maxZycie += 5;
                }
            }
            zd.akualneZycie = zd.maxZycie;

        }


        #endregion

        if (GUI.Button(new Rect(200,60,100,100),"Gotowe",StylPrzyciskow))
        {
            czyPokazac = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            //    Kamera.enabled = true;

        }

        GUI.DragWindow();

    }


}
