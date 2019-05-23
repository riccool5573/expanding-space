using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirror : MonoBehaviour
{
    bool timeron;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.5f;
    }

    private void Update()
    {
        if (timeron)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            timeron = false;
            timer = 0.5f;
        }
    }
    // Update is called once per frame
    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.collider.tag=="Player" && Input.GetKey(KeyCode.F) && timeron == false)
        {
            timeron = true;
            if (gameObject.tag == "North")
            {
                Debug.Log("got here");
                gameObject.tag = "East";
            }
            if (gameObject.tag == "East")
            {
                gameObject.tag = "South";
            }
            if (gameObject.tag == "South")
            {
                gameObject.tag = "West";
            }
            if (gameObject.tag == "West")
            {
                gameObject.tag = "North";
            }
        }
    }
}
