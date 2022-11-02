using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Glowne : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BtnGra()
    {
        SceneManager.LoadScene(1);
    }

    public void BtnOgrze()
    {
        SceneManager.LoadScene(2);
    }

    public void BtnRozpocznij()
    {
        SceneManager.LoadScene(3);
    }

    public void BtnWroc()
    {
        SceneManager.LoadScene(0);
    }

 

    public void BtnWyjdz()
    {
        Application.Quit();
    }
}
