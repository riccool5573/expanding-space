using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public bool open;
    public Sprite opendoor;
    public Sprite closeddoor;
    private SpriteRenderer spriteR;
    public camerashake cameraShake;
    private bool opened = false;
    // Start is called before the first frame update
    void Start()
    {

        spriteR = gameObject.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Find("button");
        button cs = go.GetComponent<button>();
        open = cs.active;


        if (open == true)
        {

            spriteR.sprite = opendoor; 

            GetComponent<BoxCollider2D>().enabled = false;
            transform.position = new Vector3(transform.position.x,  11.74f , transform.position.z);
            if (!opened)
            {
                StartCoroutine(cameraShake.Shake(.1f, .2f));
            }
            opened = true;
        }
        if (open == false)
        {

            spriteR.sprite = closeddoor;
       
            GetComponent<BoxCollider2D>().enabled = true;
            transform.position = new Vector3(transform.position.x, 13.39f, transform.position.z);
            if (opened)
            {
                StartCoroutine(cameraShake.Shake(.1f, .2f));
            }
            opened = false;
        }
    }
    }


