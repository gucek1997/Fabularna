using UnityEngine;
using System.Collections;

public class AIPrzeciwnik : MonoBehaviour
{

    public float predkoscObrotu = 6.0f;

    public bool gladkiObrot = true;


    public float predkoscRuchu = 5.0f;
    public float zasiegWzroku = 30f;
    public float odstepOdGracza = 2f;

    private Transform mojObiekt;
    private Transform gracz;
    private bool patrzNaGracza = false;
    private Vector3 pozycjaGraczaXYZ;

    private StrzalWrogaKula strzalKula;

    public enum TypAtaku { Kula };

    public TypAtaku typAtaku;
    private Animation Anim;

    void Start()
    {
        mojObiekt = transform;

        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }

        strzalKula = (StrzalWrogaKula)gameObject.GetComponent<StrzalWrogaKula>();

        Anim = gameObject.GetComponent<Animation>();
        Anim.Play("ElfMage_Walk");

    }

    void Update()
    {
        gracz = GameObject.FindWithTag("Gracz").transform;


        pozycjaGraczaXYZ = new Vector3(gracz.position.x, mojObiekt.position.y, gracz.position.z);

        float dist = Vector3.Distance(mojObiekt.position, gracz.position);

        patrzNaGracza = false;

        if (dist <= zasiegWzroku && dist > odstepOdGracza)
        {
            patrzNaGracza = true;


            mojObiekt.position = Vector3.MoveTowards(mojObiekt.position, pozycjaGraczaXYZ, predkoscRuchu * Time.deltaTime);

          

            WykonajAtak();

        }
        else if (dist <= odstepOdGracza)
        {
            patrzNaGracza = true;
            
            WykonajAtak();

        }

        patrzNaMnie();
    }


    void patrzNaMnie()
    {
        if (gladkiObrot && patrzNaGracza == true)
        {


            Quaternion rotation = Quaternion.LookRotation(pozycjaGraczaXYZ - mojObiekt.position);

            mojObiekt.rotation = Quaternion.Slerp(mojObiekt.rotation, rotation, Time.deltaTime * predkoscObrotu);
          
        }
        else if (!gladkiObrot && patrzNaGracza == true)
        {


            transform.LookAt(pozycjaGraczaXYZ);
    
        }



    }

    private void WykonajAtak()
    {
        
        switch (typAtaku)
        {
            case TypAtaku.Kula:
                if (strzalKula != null)
                {
                   
                    strzalKula.strzal();
                }
                break;

        }


    }

    }
