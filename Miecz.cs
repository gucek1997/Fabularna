using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miecz : MonoBehaviour
{
    public Animator MieczAnimacja;
    public float timer;
    public float Cooldown;
    public int Obrazenia;
    public Transform Kamera;




    void Start()
    {
        
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {

            if (Cooldown <timer)
            {
                MieczAnimacja.SetTrigger("Uderz");
                timer = 0.0f;
                Ray ray = new Ray(Kamera.position, Kamera.forward);
                RaycastHit HitPozycja;
             


            }

        }
        
    }
}
