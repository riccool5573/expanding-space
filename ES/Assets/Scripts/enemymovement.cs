using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymovement : MonoBehaviour
{
    public GameObject Player;
    public float speed;
    private bool light;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.Find("player");
        movement cs = Player.GetComponent<movement>();
        light = cs.lighton;

        if (light)
        {
            if (Player.transform.position.x < transform.position.x)
            {
                Vector3 myVec = new Vector3(-1, 0, 0);
                transform.position += myVec * speed * Time.deltaTime;
            }
            if (Player.transform.position.x > transform.position.x)
            {
                Vector3 myVec = new Vector3(1, 0, 0);
                transform.position += myVec * speed * Time.deltaTime;
            }
            if (Player.transform.position.y < transform.position.y)
            {
                Vector3 myVec = new Vector3(0, -1, 0);
                transform.position += myVec * speed * Time.deltaTime;
            }
            if (Player.transform.position.y > transform.position.y)
            {
                Vector3 myVec = new Vector3(0, 1, 0);
                transform.position += myVec * speed * Time.deltaTime;
            }
        }



    }
}
