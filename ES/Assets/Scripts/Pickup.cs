using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int amountoffireflies;
    private string facing;
    public Transform firefly;
    private double firetimer;
    private bool timeron;
    private bool hasrock;
    public Transform Rock;
    private double rocktimer;
    private bool rocktimeron;
    Animator animator;
    private GameObject Holder;
    // Start is called before the first frame update
    void Start()
    {
        
        Holder = GameObject.Find("Holder");
        holder cs = Holder.GetComponent<holder>();
        amountoffireflies = cs.fireflies;
        animator = GetComponent<Animator>();
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
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W))
        {
            looking();
        }

      
        if (Input.GetKey(KeyCode.A))
        {
            facing = "Left";
            animator.SetBool("left", true);
            animator.SetBool("right", false);
            animator.SetBool("up", false);
            animator.SetBool("down", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            facing = "Right";
            animator.SetBool("left", false);
            animator.SetBool("right", true);
            animator.SetBool("up", false);
            animator.SetBool("down", false);
        }
        if (Input.GetKey(KeyCode.W))
        {
            facing = "Up";
            animator.SetBool("left", false);
            animator.SetBool("right", false);
            animator.SetBool("up", true);
            animator.SetBool("down", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            facing = "Down";
            animator.SetBool("left", false);
            animator.SetBool("right", false);
            animator.SetBool("up", false);
            animator.SetBool("down", true);
        }
        if(Input.anyKey == false)
        {
            animator.SetBool("left", false);
            animator.SetBool("right", false);
            animator.SetBool("up", false);
            animator.SetBool("down", false);
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


    public void looking()
    {
        if (Input.GetKey(KeyCode.A))
        {
            facing = "Left";
            animator.SetBool("left", true);
            animator.SetBool("right", false);
            animator.SetBool("up", false);
            animator.SetBool("down", false);
        }
      else  if (Input.GetKey(KeyCode.D))
        {
            facing = "Right";
            animator.SetBool("left", false);
            animator.SetBool("right", true);
            animator.SetBool("up", false);
            animator.SetBool("down", false);
        }
       else if (Input.GetKey(KeyCode.W))
        {
            facing = "Up";
            animator.SetBool("left", false);
            animator.SetBool("right", false);
            animator.SetBool("up", true);
            animator.SetBool("down", false);
        }
       else if (Input.GetKey(KeyCode.S))
        {
            facing = "Down";
            animator.SetBool("left", false);
            animator.SetBool("right", false);
            animator.SetBool("up", false);
            animator.SetBool("down", true);
        }
       else if (Input.anyKey == false)
        {
            animator.SetBool("left", false);
            animator.SetBool("right", false);
            animator.SetBool("up", false);
            animator.SetBool("down", false);
        }
    }

}
