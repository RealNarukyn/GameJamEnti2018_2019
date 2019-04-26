using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;

    PlayerInput player;

    int health;
    int damage;

    enum States
    {
        Idle,
        MoveCloser
    }
    States state;
    States State
    {
        get
        {
            return state;
        }
        set
        {
                state = value;
                int intState = (int)state;
                state = (States)Mathf.Clamp(intState, 0, 1);
                //Debug.Log("Changed to state" + state);
        }
    }

    void Start()
    {
        state = States.Idle;

        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Jugador").GetComponent<PlayerInput>();
    }

    void FixedUpdate()
    {
        switch (State)
        {
            case States.Idle:
                Idle();
                break;
            case States.MoveCloser:
                MoveCloser();
                break;
        }
    }

    // Looking for an enemy to slave
    void Idle()
    {
        // Do nothing
    }

    // Follow the enemy
    void MoveCloser()
    {
        rb.position = Vector2.MoveTowards(rb.position, player.transform.position, 3 * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Jugador") {
            player = collider.GetComponent<PlayerInput>();

            if (player.is_lightOn)
             State =States.MoveCloser;

            if (!player.is_lightOn)
                State = States.Idle;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Jugador")
        {
            player = collider.GetComponent<PlayerInput>();
                State = States.Idle;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Jugador")
        {
            player.Die();
        }
    }
}