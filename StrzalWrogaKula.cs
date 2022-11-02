using UnityEngine;
using System.Collections;


public class StrzalWrogaKula : StrzalWroga
{

    public float czekaj = 2f;

    public float odliczanieDoStrzalu = 1f;

    public GameObject kulka;
    public float predkosc = 30;


    public void strzal()
    {

        odliczanieDoStrzalu -= Time.deltaTime;


        if (odliczanieDoStrzalu <= 0 && namierzanie())
        {
            odliczanieDoStrzalu = czekaj;

            GameObject kula;
            kula = (GameObject)Instantiate(kulka, transform.position + transform.forward, Quaternion.identity);

            kula.GetComponent<Rigidbody>().AddForce(transform.forward * predkosc, ForceMode.Impulse);

        }

    }
}
