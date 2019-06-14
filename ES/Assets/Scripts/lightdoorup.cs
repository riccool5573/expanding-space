using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightdoorup : MonoBehaviour
{
    bool opened;
    public camerashake cameraShake;
    private SpriteRenderer spriteR;
    public Sprite opendoor;
    public Sprite closeddoor;
    // Start is called before the first frame update
    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();

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
            if (!opened)
            {
                StartCoroutine(cameraShake.Shake(.1f, .2f));
            }
            opened = true;
        }
        else if (open == false)
        {
            GetComponent<SpriteRenderer>().enabled = true;

            GetComponent<BoxCollider2D>().enabled = true;
        
            if (opened)
            {
                StartCoroutine(cameraShake.Shake(.1f, .2f));
            }
            opened = false;

        }
    }
}

