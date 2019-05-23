using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour
{
    public bool on;
    public Transform Light;
    // Start is called before the first frame update
    void Start()
    {
        on = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider)
        {
            if (other.collider.tag == "Player" && Input.GetKeyDown(KeyCode.E))
            {
                if (on == false)
                {
                    Debug.Log("got here");
                    on = true;
                    Instantiate(Light, new Vector3(transform.position.x - 1, transform.position.y + 0.5f), Quaternion.identity);
                }
                else
                {
                    on = false;
                    Debug.Log("got here");
                }
            }

        }
    }
}
