using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymovement : MonoBehaviour
{
    public GameObject Player;
    public float speed;
    private bool lighton;
    private GameObject Closest;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.Find("player");
        movement cs = Player.GetComponent<movement>();
        lighton = cs.lighton;
        FindClosestEnemy();

        // als player light aan heeft staan gaat enemy eropaf
        if (lighton)
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
        if (!lighton && Closest != null)
        {
            if (Closest.transform.position.x < transform.position.x)
            {
                Vector3 myVec = new Vector3(-1, 0, 0);
                transform.position += myVec * speed * Time.deltaTime;
            }
            if (Closest.transform.position.x > transform.position.x)
            {
                Vector3 myVec = new Vector3(1, 0, 0);
                transform.position += myVec * speed * Time.deltaTime;
            }
            if (Closest.transform.position.y < transform.position.y)
            {
                Vector3 myVec = new Vector3(0, -1, 0);
                transform.position += myVec * speed * Time.deltaTime;
            }
            if (Closest.transform.position.y > transform.position.y)
            {
                Vector3 myVec = new Vector3(0, 1, 0);
                transform.position += myVec * speed * Time.deltaTime;
            }
        }



    }
    GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("firefly");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
                Closest = closest;
            }
        }
        return closest;
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.rigidbody)
        { 
        if (other.rigidbody.tag == "firefly")
            {
                    Destroy(other.gameObject);
                   
               
            }
        }
    }
}
