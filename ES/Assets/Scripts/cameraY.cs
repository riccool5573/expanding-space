using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraY : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(0, Player.position.y, -10);
    }
}
