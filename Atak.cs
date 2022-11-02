using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atak : MonoBehaviour
{
    public Transform PoczatekMiecz;
    public Transform KoniecMiecz;
    public int odejmowanieZdrowia = 10;
    public float sila = 0.9f;
    public float czas = 1;
    public bool uderzac = false;
    public Animator MieczAnimacja;
    public int Animacja;
    public Random rmd; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit uderzenie;
        Vector3 kierunek_miecz = PoczatekMiecz.TransformDirection(Vector3.forward);
        PoczatekMiecz.LookAt(KoniecMiecz);
        /*if (Input.GetMouseButton(0) && uderzac == false)
        {
            czas -= Time.deltaTime;
            //  MieczAnimacja.SetTrigger("Miecz");
            Animacja = Random.Range(0, 2);

        }
        if (czas > 0 && czas < 1)
        {
            uderzac = true;
            czas -= Time.deltaTime;
        }
        else
        {
            uderzac = false;
            czas = 1;
      */ 
        if (Input.GetMouseButton(0))
        {
      //      if (Input.GetMouseButton(0))
            {
                czas -= Time.deltaTime;

                if (czas > 0 && czas < 1)
                {
                    uderzac = true;
                    czas -= Time.deltaTime;

                    if (Animacja == 0)
                    {
                        Debug.DrawRay(PoczatekMiecz.position, kierunek_miecz * sila, Color.red);
                        if (Physics.Raycast(PoczatekMiecz.position, kierunek_miecz, out uderzenie, sila))
                        {
                            uderzenie.collider.SendMessageUpwards("Hp", -odejmowanieZdrowia, SendMessageOptions.DontRequireReceiver);


                        }
                    }

                }
                else
                {
                    uderzac = false;
                    czas = 1;
                }
        
                /*
                if (Animacja == 0)
                {
                    Debug.DrawRay(PoczatekMiecz.position, kierunek_miecz * sila, Color.red);
                    if (Physics.Raycast(PoczatekMiecz.position, kierunek_miecz, out uderzenie, sila))
                    {
                        uderzenie.collider.SendMessageUpwards("Hp", -odejmowanieZdrowia, SendMessageOptions.DontRequireReceiver);


                    }
                }
                */
            }
        }


    }
}
