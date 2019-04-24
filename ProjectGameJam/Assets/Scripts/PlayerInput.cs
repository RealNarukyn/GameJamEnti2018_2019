using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public SpriteRenderer black_background; 
    public SpriteRenderer linterna; 

	// Use this for initialization
	void Start () {
        //black_background = GameObject.Find("BlackBackground").GetComponent<SpriteRenderer>();
        //linterna = GameObject.Find("Linterna").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            black_background.enabled = false;
            linterna.enabled = true;

        }
        else {
            black_background.enabled = true;
            linterna.enabled = false;
        }
    }




}
