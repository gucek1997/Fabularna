using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misja_1 : MonoBehaviour
{
    public GameObject NPC_Drewno;

    void Start()
    {
        
    }

    void Update()
    {
       
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Gracz")
        {
            NPC_Drewno.GetComponent<Dialog_2>().SpelnionoWarumek = true;
        }
    }
}
