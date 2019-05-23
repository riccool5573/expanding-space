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
    // Start is called before the first frame update
    void Start()
    {
        east = true;

        tr = GetComponent<TrailRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Find("Altar");
        Altar cs = go.GetComponent<Altar>();
        exists = cs.on;
        if (north)
        {
            transform.localPosition += new Vector3(0, 0.2f, 0);
        }
        if (south)
        {
            transform.localPosition += new Vector3(0, -0.2f, 0);
        }
        if (east)
        {
            transform.localPosition += new Vector3(0.2f, 0, 0);
        }
        if (west)
        {
            transform.localPosition += new Vector3(-0.2f, 0, 0);
        }
        if(exists == false)
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
