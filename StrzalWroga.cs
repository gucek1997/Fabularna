using UnityEngine;
using System.Collections;


public class StrzalWroga : MonoBehaviour
{

    
    protected Transform gracz;
    
    private Vector3 pozycjaGraczaXYZ;
   
    private Quaternion rotacjaPocisku;

   
    protected GameObject graczObiekt;

  
    public float katWidzenia = 160f;


    protected Vector3 hitPoint;

    void Start()
    {
        graczObiekt = GameObject.FindWithTag("Gracz");
        
        gracz = graczObiekt.transform;
    }

  
    protected bool namierzanie()
    {
        if (gracz != null)
        {
         
            float angle = Quaternion.Angle(gracz.rotation, transform.rotation);
       
            if (angle >= katWidzenia)
            {
                return true;
            }
        }
        return false;
    }

 
    public Quaternion getRotacjaPocisku()
    {
  
        pozycjaGraczaXYZ = new Vector3(gracz.position.x, gracz.position.y, gracz.position.z);

        
        rotacjaPocisku = Quaternion.LookRotation(pozycjaGraczaXYZ - transform.position);
        return rotacjaPocisku;
    }

}
