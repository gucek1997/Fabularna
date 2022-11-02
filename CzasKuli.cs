using UnityEngine;
using System.Collections;

class CzasKuli : MonoBehaviour
{


    public float czasZycia = 1f;


    void Update()
    {
        czasZycia -= Time.deltaTime;


        if (czasZycia <= 0)
        {

            Destroy(gameObject);
        }
    }

}
