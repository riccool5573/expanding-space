using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private int amountoffireflies;
    private string facing;
    public Transform firefly;
    private double firetimer;
    private bool timeron;
    private bool hasrock;
    public Transform Rock;
    private double rocktimer;
    private bool rocktimeron;
    // Start is called before the first frame update
    void Start()
    {
        amountoffireflies = 0;
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.rigidbody)
        {
            if (other.rigidbody.tag == "Rock" && rocktimer <= 0)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    hasrock = true;
                    rocktimer = 0.5;
                    rocktimeron = true;
                    Debug.Log("got here");
                    Destroy(other.gameObject);
                }
            }
            if (other.rigidbody.tag == "firefly" && firetimer <= 0)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    amountoffireflies++;
                    firetimer = 0.5;
                    timeron = true;
                    Destroy(other.gameObject);
                   
                }
            }
        }

    }
    private void Update()
    {
        Debug.Log(rocktimer);
       
        //rocktimer en rocktimeron is om ervoor te zorgen dat het object niet meteen weer word neergezet het moment dat het word opgepakt
        if (rocktimeron)
        {
            rocktimer -= Time.deltaTime;
        }
        if (rocktimer <= 0)
        {
            rocktimeron = false;
        }
        if (timeron)
        {
            firetimer -= Time.deltaTime;
        }
        if (firetimer <= 0)
        {
            timeron = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            facing = "Left";
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            facing = "Right";
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            facing = "Up";
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            facing = "Down";
        }
        if (Input.GetKeyDown(KeyCode.Space))   
        {
            if (amountoffireflies > 0)
            {

                    if (facing == "Up")
                    {
                        //spawnt firefly. moest % 10 gebruiken omdat transform kut is en een double is.
                        Instantiate(firefly, new Vector3(transform.position.x, transform.position.y + 1 % 10), Quaternion.identity);
                    }
                    if (facing == "Down")
                    {
                        Instantiate(firefly, new Vector3(transform.position.x, transform.position.y - 1 % 10), Quaternion.identity);
                    }
                    if (facing == "Right")
                    {   //hier is het divided omdat % niet werkte en hem te ver weg zette
                        Instantiate(firefly, new Vector3(transform.position.x + 1 % 10, transform.position.y), Quaternion.identity);
                    }
                    if (facing == "Left")
                    {
                        Instantiate(firefly, new Vector3(transform.position.x - 1 % 10, transform.position.y), Quaternion.identity);
                    }
                    amountoffireflies--;


            }
        }
        if (hasrock == true && Input.GetKeyDown(KeyCode.R))
        {
            if (rocktimer <= 0)
            {
                if (facing == "Up")
                {
                    //spawnt firefly. moest % 10 gebruiken omdat transform kut is en een double is.
                    Instantiate(Rock, new Vector3(transform.position.x, transform.position.y + 1 % 10), Quaternion.identity);
                }
                if (facing == "Down")
                {
                    Instantiate(Rock, new Vector3(transform.position.x, transform.position.y - 1 % 10), Quaternion.identity);
                }
                if (facing == "Right")
                {   //hier is het divided omdat % niet werkte en hem te ver weg zette
                    Instantiate(Rock, new Vector3(transform.position.x + 1 % 10, transform.position.y), Quaternion.identity);
                }
                if (facing == "Left")
                {
                    Instantiate(Rock, new Vector3(transform.position.x - 1 % 10, transform.position.y), Quaternion.identity);
                }
                hasrock = false;
            }
        }
    }

  
}
