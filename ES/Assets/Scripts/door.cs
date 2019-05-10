using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public bool open;
    // Start is called before the first frame update
    void Start()
    {

       

    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Find("button");
        button cs = go.GetComponent<button>();
        open = cs.active;


        if (open == true)
        {

            GetComponent<SpriteRenderer>().enabled = false;

            GetComponent<BoxCollider2D>().enabled = false;
        }
        else if(open == false)
        {
            GetComponent<SpriteRenderer>().enabled = true;

            GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
