using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zycie : MonoBehaviour
{

    public Transform pozycjaPostaci;
    public CharacterController characterCont;
    public float pozycjaY;
    public float pozycjaPrzedSkokiem;
    public float pozycjaPoSkoku;
    public bool czyPostacSpada;

    public float maxZycie;
    public float akualneZycie;


    public GameObject pasekZycia;

    void Start()
    {
        maxZycie = 100;
        akualneZycie = 100;
    }

    void Update()
    {
        /*  //Obrazenia od upadku
          if (characterCont.isGrounded == true && czyPostacSpada==true)
          {
              pozycjaY = pozycjaPostaci.position.y;
          }
          if (characterCont.isGrounded == false)
          {
              pozycjaPrzedSkokiem = pozycjaY;
              czyPostacSpada = false;
          }
          if (characterCont.isGrounded == true && czyPostacSpada == false)
          {
              pozycjaPoSkoku = pozycjaPostaci.position.y;
              if (pozycjaPrzedSkokiem - pozycjaPoSkoku > 3)
              {
                  akualneZycie -= 15;

              }
          }

          */

        pasekZycia.transform.localScale = new Vector3(akualneZycie / maxZycie, 1, 0);


        /*if (akualneZycie < maxZycie)
        {
            akualneZycie += 1 * Time.deltaTime;

        }
        */

        if (akualneZycie <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(5);
         }




    }



    public void otrzymaneObrazenia(float obrazenia)
    {
      
        akualneZycie -= obrazenia;
      
    }





    public bool czyMartwy()
    {
        if (akualneZycie <= 0)
        {
            return true;
        }
        return false;
    }






}
