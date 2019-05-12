using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private float moveInputx;
    private float moveInputy;
    public float speed;
    private Rigidbody2D rb;
    public bool lighton;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
   
    }

    // Update is called once per frame
    void Update()
    {
        //track welke kant player op kijkt. kan later gebruikt worden voor animations
       

        //set lights aan of uit.
        if (lighton == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                lighton = true;
            }
        }
        else if (lighton == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                lighton = false;    
            }
        }
    }
  
    private void FixedUpdate()
    {
        //movement
        moveInputx = Input.GetAxis("Horizontal");
        moveInputy = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveInputy * speed, rb.velocity.y);
        rb.velocity = new Vector2(moveInputx * speed, rb.velocity.x);
    }
}
