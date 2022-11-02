using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Koniec_Gry : MonoBehaviour
{
    public GameObject Studnia;
    bool wejscie;
    public GUISkin skin;


    void Start()
    {

    }

    void Update()
    {
    
            if (wejscie == true)
            {
               if (Input.GetKeyDown(KeyCode.F))
                {

                SceneManager.LoadScene(4);
                }
            }
        
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Koniec")
        {
            Studnia = col.gameObject;
            wejscie = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Koniec")
        {
            Studnia = null;
            wejscie = false;
        }

    }


    void OnGUI()
    {
        if (wejscie == true)
        {

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 200, 200), "Naciśnij F żeby wskoczyć do studni", skin.GetStyle("Wejscie"));

        }
    }



}
