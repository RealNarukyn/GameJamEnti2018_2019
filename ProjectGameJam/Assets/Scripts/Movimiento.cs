using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimiento : MonoBehaviour {


    private float vel = 4.0f;
    public Rigidbody2D rb;
    public AudioSource pasos;
    private bool andar;

    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        andar = false;
    }

    // Update is called once per frame
    void Update()
    {

        FaceMouse();
    
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-vel, rb.velocity.y);
            andar = true;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(vel, rb.velocity.y);
            andar = true;
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            andar = false;
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, vel);
            andar = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
           rb.velocity = new Vector2(rb.velocity.x, -vel);
            andar = true;
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
         
        }

        if (andar == true)
        {
            if (!pasos.isPlaying)
                pasos.Play();
        }
        else
        {
            pasos.Stop();
        }
    }

    void FaceMouse()
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Vector2 direccion = new Vector2(
                mousePosition.x - transform.position.x,
                mousePosition.y - transform.position.y
                );

            transform.up = direccion;
        }
}

