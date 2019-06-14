using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightpuzzle : MonoBehaviour
{
    private bool north;
    private bool south;
    private bool east;
    private bool west;
    private bool exists;
    private TrailRenderer tr;
    public GameObject spritemaskhorizontal;
    public GameObject spritemaskvertical;
    // Start is called before the first frame update
    void Start()
    {
        east = true;
        tr = GetComponent<TrailRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
      
        if (true)
        {
            if (east || west)
            {
                Instantiate(spritemaskhorizontal, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
            }
            if (north || south)
            {
                Instantiate(spritemaskvertical, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
            }
        }
        GameObject go = GameObject.Find("Altar");
        Altar cs = go.GetComponent<Altar>();
        exists = cs.on;
        if (north)
        {
            transform.localPosition += new Vector3(0, 0.2f, 0);
        }
       else if (south)
        {
            transform.localPosition += new Vector3(0, -0.2f, 0);
        }
        else if (east)
        {
            transform.localPosition += new Vector3(0.2f, 0, 0);
        }
       else if (west)
        {
            transform.localPosition += new Vector3(-0.2f, 0, 0);
        }
        else
        {
            transform.localPosition += new Vector3(0, 0, 0);
        }
        if (exists == false)
        {
            Destroy(this);
            tr.Clear();
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {

        if (other.collider)
        {

            if(other.collider.tag == "North")
            {
                GetComponent<ConstantForce2D>().force = new Vector3(0, 0, 0);

                north = true;
                west = false;
                east = false;
                south = false;
            }
            if (other.collider.tag == "East")
            {
                GetComponent<ConstantForce2D>().force = new Vector3(0, 0, 0);

                north = false;
                west = false;
                east = true;
                south = false;
            }
            if (other.collider.tag == "South")
            {
                GetComponent<ConstantForce2D>().force = new Vector3(0, 0, 0);

                north = false;
                west = false;
                east = false;
                south = true;
            }
            if (other.collider.tag == "West")
            {
                GetComponent<ConstantForce2D>().force = new Vector3(0, 0, 0);

                north = false;
                west = true;
                east = false;
                south = false;
            }
            if (other.collider.tag == "LightButton"){
                north = false;
                west = false;
                east = false;
                south = false;
            }
        }
    }
}
