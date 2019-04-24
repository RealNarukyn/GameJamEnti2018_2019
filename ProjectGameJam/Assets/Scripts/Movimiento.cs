using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {


    private float vel = 4.0f;
    public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-vel, rb.velocity.y);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(vel, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, vel);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, -vel);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }


    }
}
