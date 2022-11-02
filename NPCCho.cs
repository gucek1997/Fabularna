using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))] 
public class NPCCho : MonoBehaviour
{
    public Transform[] Punkty;
    public float SzybkoscRuch = 1;
    public bool czyZapetlac = true;
    private CharacterController Kontroler;
    private Vector3 Grawitacja;
    public int ObecnyCel;


    // Start is called before the first frame update
    void Start()
    {

        Kontroler = GetComponent<CharacterController>();


    }

    // Update is called once per frame
    void Update()
    {
        
        if (Kontroler != null)
        {
            if (Kontroler.isGrounded)
            {
                Ruch();
            }
            else
            {
                Grawitacja = new Vector3(0, 0, 0);
                Kontroler.Move(Grawitacja);
            }
        }
        
    }

    public void Ruch()
    {
        if (ObecnyCel < Punkty.Length)
        {
            Vector3 KierunekRuchu = Punkty[ObecnyCel].position - transform.position;
            if (KierunekRuchu.magnitude < 50)
            {
                ObecnyCel++;
                Kontroler.Move(KierunekRuchu * SzybkoscRuch * Time.deltaTime);    
            }


        }
        else
        {
            if (czyZapetlac)
            {
                ObecnyCel = 0;
            }
         

        }
        if (ObecnyCel < Punkty.Length)
        {
            transform.LookAt(Punkty[ObecnyCel].position);
        }


    }



}
