using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public SpriteRenderer door_sprite_closed;
    public SpriteRenderer door_sprite_open;
    public BoxCollider2D col;
    public bool is_locked;

	// Use this for initialization
	void Start () {
        is_locked = true;
    }
	
	// Update is called once per frame
	void Update () {}

    public void DoorAction()
    {
        door_sprite_closed.enabled = false;
        is_locked = false;
        col.enabled = false;
        door_sprite_open.enabled = true;
    }
}
