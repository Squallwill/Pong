using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRacket : MonoBehaviour
{
    public string axis;
    public float speed = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this is the input axis
        float v = Input.GetAxisRaw(axis) * speed;
        //velocity vector
        GetComponent < Rigidbody2D>().velocity = new Vector2(0, v);
    }
}
