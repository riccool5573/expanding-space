using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Find("LightButton");
        LightButton cs = go.GetComponent<LightButton>();
       bool open = cs.active;


        if (open == true)
        {

            GetComponent<SpriteRenderer>().enabled = false;

            GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (open == false)
        {
            GetComponent<SpriteRenderer>().enabled = true;

            GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
}
