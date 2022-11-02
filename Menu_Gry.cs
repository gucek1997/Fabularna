using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Menu_Gry : MonoBehaviour
{
    public static bool GraPause = false;

    public GameObject EscMenu;


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (GraPause)
            {
                PrzyciskWroc();


            }
            else
            {

                Pauza();
                

            }
        }
    }

    void Pauza()
    {
        EscMenu.SetActive(true);
        Time.timeScale = 0f;
        GraPause = true;
      
    }

    public void PrzyciskWroc()
    {
        EscMenu.SetActive(false);
        Time.timeScale = 1f;
        GraPause = false;
     //   Cursor.lockState = CursorLockMode.Locked;

    }


    public void PrzyciskDoMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void PrzyciskWyjscie()
    {
        Application.Quit();
    }

    private void OnGUI()
    {
        if (GraPause == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
        else
        {


        }

    }







}
