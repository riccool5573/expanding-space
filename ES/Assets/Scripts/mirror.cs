using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirror : MonoBehaviour
{
    bool timeron;
    float timer;
    int i = 0;
    public string[] NESW = { "North","East","South","West" };
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
            timer = 1.0f;
        }
    }
    // Update is called once per frame
    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.collider.tag=="Player" && Input.GetKey(KeyCode.F) && timeron == false)
        {
            i++;
            if (i >= 4)
            {
                i = 0;
            }
            gameObject.tag = NESW[i];
            timeron = true;
           
          
        }
    }
}
