using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doswiadczenie : MonoBehaviour
{

    public GameObject Gracz;
    public float odleglosc;
    public float predkosc;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ruch();
    }

    public void Ruch()
    {
        Gracz = GameObject.FindGameObjectWithTag("Gracz");
        Vector3 odlegloscOdGracza = Gracz.transform.position - transform.position;
        odleglosc = odlegloscOdGracza.magnitude;
        Vector3 cel = Gracz.transform.position;
        Vector3 Kierunekruchu = cel - transform.position;
        float szybkosc = odleglosc;
        GetComponent<Rigidbody>().velocity = (Kierunekruchu.normalized / szybkosc) * predkosc;
        if (odleglosc < 1)
        {
            transform.transform.position = new Vector3(transform.position.x, transform.position.y , transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider inne)
    {
        if (inne.tag == "Gracz")
        {
            inne.SendMessageUpwards("DodawanieExp", 50 , SendMessageOptions.DontRequireReceiver);
            Destroy(transform.gameObject);
        }
    }
    }


