using UnityEngine;
using System.Collections;


public class Obrazenia : MonoBehaviour
{

    public float obrazenia = 5f;


    void OnCollisionEnter(Collision kontakt)
    {
        GameObject go = kontakt.gameObject;
        Zycie zycie = (Zycie)go.GetComponent<Zycie>();
        if (zycie != null)
        {
            zycie.otrzymaneObrazenia(obrazenia);
        }
    }


}
