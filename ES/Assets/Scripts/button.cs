using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public bool active = false;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" || other.tag =="heavy" || other.tag == "Rock")
        {

            active = true;
        }
       
    }
   
    private void OnTriggerExit2D(Collider2D other)
    {


        if (other.tag == "Player" || other.tag == "heavy" || other.tag == "Rock") { 

        active = false;
        }
       
    }
}
