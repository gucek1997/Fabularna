using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGui(Collider Quiz)
    {


        if (Quiz.CompareTag("Gracz"))
        {

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;


        }
        }
    }





