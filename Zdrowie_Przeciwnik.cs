using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zdrowie_Przeciwnik : MonoBehaviour
{

    public int MaxHp = 300;
    public int ObecneHp = 300;
    public float SzerokoscOkna;
    public GameObject ZDP;
    public GameObject _zdrowie;
    private Transform mojaTransformacja;
    public Transform Gracz;
    public float czas = 1;
    public GameObject ja;
    private Animation Anim;
    public CharacterController Kontroler;
    private GameObject Exper;
    public Transform EXP;
    // Start is called before the first frame update
    void Start()
    {
        mojaTransformacja = transform;
        Kontroler = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Hp(0);
        ZDRO();

        if(ObecneHp <=0)
        {

            ObecneHp = 0;
            czas -= Time.deltaTime;
            if (czas < 0)
            {
                Instantiate(EXP, mojaTransformacja.position, Quaternion.identity);
                Destroy(Kontroler);
                Destroy(ja);
                Destroy(ZDP);
                
            }


        }

    }

    public void ZDRO()
    {
       
        GameObject[] ZdrowiePrzeciwnika_ile = GameObject.FindGameObjectsWithTag("ZdrowiePrzeciwnika");
        float iloscZdrowiaPrzeciwnika = ZdrowiePrzeciwnika_ile.Length;
        GameObject[] Przeciwnicy = GameObject.FindGameObjectsWithTag("Przeciwnik");

        if (iloscZdrowiaPrzeciwnika < Przeciwnicy.Length)
        {
            ZDP = Instantiate(_zdrowie) as GameObject;
        }

        ZDP.transform.position = new Vector3(mojaTransformacja.position.x, mojaTransformacja.position.y, mojaTransformacja.position.z);
        ZDP.transform.localScale = new Vector3(SzerokoscOkna / 90, 0.3f, 0);
        ZDP.transform.LookAt(Gracz);

    }

    public void Hp(int aaa)
    {
        ObecneHp += aaa;
        SzerokoscOkna = (Screen.width / 2) * (ObecneHp / (float)MaxHp);

    }


    public bool czyMartwy()
    {
        if (ObecneHp <= 0)
        {
            return true;
        }
        return false;
    }


}
