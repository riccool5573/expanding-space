using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holder : MonoBehaviour
{
    public int fireflies;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

    }
    // Update is called once per frame
    void Update()
    {
        Player = GameObject.Find("player");
        Pickup cs = Player.GetComponent<Pickup>();
        fireflies = cs.amountoffireflies;


    }
}
