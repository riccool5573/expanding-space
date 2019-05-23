using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightButton : MonoBehaviour
{
    // Start is called before the first frame update
    public bool active = false;
    // Start is called before the first frame update   
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider)
        {
            if (other.collider.tag == "Light")
            {
                active = true;
            }
        }
    }

    private void OnCollisionExit2D(Collider2D other)
    {


        if (other.tag == "Light")
        {

            active = false;
        }

    }
}
