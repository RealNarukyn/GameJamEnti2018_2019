using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public SpriteRenderer door_sprite;
    public bool is_locked;

	// Use this for initialization
	void Start () {
        door_sprite = GetComponent<SpriteRenderer>();

        is_locked = true;
    }
	
	// Update is called once per frame
	void Update () {}

    public void DoorAction()
    {
            door_sprite.color = Color.green;
            is_locked = false;
    }
}
