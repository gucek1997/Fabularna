using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sterowanie_Klawiatura : MonoBehaviour
{


    public CharacterController characterControler;

    private Canvas EscMenu;
    public Button BtnDoMenu;
    public Button BtnWyjdz;
    public Button BtnWroc;

    public float poruszanie = 10.0f;
    public float skok = 8.0f;
    public float aktualnyskok = 0f;
    public float bieganie = 12.0f;
    public float czuloscMyszki = 2.0f;
    public float myszkagd = 0.0f;
    public float zakresMyszki = 90.0f;

    void Start()
    {
        characterControler = GetComponent<CharacterController>();
    }

    void Update()
    {
        klawiatura();
        mysz();

     
    }


    private void klawiatura()
    {

        float ruchPrzodTyl = Input.GetAxis("Vertical") * poruszanie;
        float ruchLewoPrawo = Input.GetAxis("Horizontal") * poruszanie;
        // skakanie
        if (characterControler.isGrounded && Input.GetButton("Jump"))
        {
            aktualnyskok = skok;
        }
        else if (!characterControler.isGrounded)
        {
            // fizyka skoku
            aktualnyskok += Physics.gravity.y * Time.deltaTime;
        }

        Debug.Log(Physics.gravity.y);


        if (Input.GetKeyDown("left shift"))
        {
            poruszanie += bieganie;
        }
        else if (Input.GetKeyUp("left shift"))
        {
            poruszanie -= bieganie;
        }

        // ruch i obrót 
        Vector3 ruch = new Vector3(ruchLewoPrawo, aktualnyskok, ruchPrzodTyl);
        ruch = transform.rotation * ruch;

        characterControler.Move(ruch * Time.deltaTime);

    



    }


    private void mysz()
    {

        float myszLewoPrawo = Input.GetAxis("Mouse X") * czuloscMyszki;
        transform.Rotate(0, myszLewoPrawo, 0);

        myszkagd -= Input.GetAxis("Mouse Y") * czuloscMyszki;


        myszkagd = Mathf.Clamp(myszkagd, -zakresMyszki, zakresMyszki);

        Camera.main.transform.localRotation = Quaternion.Euler(myszkagd, 0, 0);

       


    }






}
