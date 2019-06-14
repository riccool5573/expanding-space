using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMask : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Find("Altar");
        Altar cs = go.GetComponent<Altar>();
       bool exists = cs.on;
        if (exists == false)
        {
            GetComponent<SpriteMask>().enabled = false;
            Destroy(this);
          
        
        }
    }
}
