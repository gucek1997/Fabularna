using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruchprzeciwnika : MonoBehaviour
{

    public Transform cel;
    private Transform mojaTransformacja;
    private CharacterController Kontroler;

    public float szybkoscRuchu = 2;
    public float grawitacja = 5;
    public float szybkoscObrotu = 250;

    private Vector3 KierunekRuchu = Vector3.zero;
    public bool czyIsc;
    public float odleglosc;

    // Start is called before the first frame update
    void Start()
    {
        mojaTransformacja = transform;
        czyIsc = false;


    }

    // Update is called once per frame
    void Update()
    {
        Odleglosc();
        CzyIsc();
    }

    public void Ruch()
    {
        if (Kontroler.isGrounded)
        {
            KierunekRuchu = new Vector3(0, 0, cel.position.z);
            KierunekRuchu = mojaTransformacja.TransformDirection(KierunekRuchu);
            KierunekRuchu *= szybkoscRuchu ;
        }
        else
        {
            KierunekRuchu.y -= grawitacja;
        }

        Kontroler.Move(KierunekRuchu * Time.deltaTime);

    }

    public void Odleglosc()
    {
        odleglosc = mojaTransformacja.position.z - cel.position.z;
        if(odleglosc <0)
        {
            odleglosc = cel.position.z - mojaTransformacja.position.z;

        }
    }

    public void CzyIsc()
    {
        if (odleglosc < 30)
        {
            czyIsc = true;
        }
        else;
        {
            czyIsc = false;
        }



    }










}
