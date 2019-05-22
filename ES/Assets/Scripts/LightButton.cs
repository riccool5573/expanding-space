using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightButton : MonoBehaviour
{
    // Start is called before the first frame update
    public bool active = false;
    // Start is called before the first frame update
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Light")
        {

            active = true;
            Debug.Log("got here");
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {


        if (other.tag == "Light")
        {

            active = false;
        }

    }
}
