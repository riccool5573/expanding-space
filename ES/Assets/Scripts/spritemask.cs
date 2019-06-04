using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class spritemask : MonoBehaviour
{
    public Transform Spritemask;
    private GameObject player;
    private bool big;
    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {

        player = GameObject.Find("player");
        movement go = player.GetComponent<movement>();
        big = go.lighton;
        if (big)
        Spritemask.localScale = new Vector3(10, 10, 0);
        else
        Spritemask.localScale = new Vector3(5, 5, 0);
            
    }
}
