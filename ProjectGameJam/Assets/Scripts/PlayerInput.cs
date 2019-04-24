using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    SpriteRenderer black_background; 
    SpriteRenderer linterna; 

	// Use this for initialization
	void Start () {
        black_background = GameObject.Find("Black_Background").GetComponent<SpriteRenderer>();
        linterna = GameObject.Find("Linterna").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("INPUT SPACE");
            Debug.Log("BlackGround: " + black_background.enabled);
            Debug.Log("Linterna: " + linterna.enabled);
            black_background.enabled = false;
            linterna.enabled = true;

        }
        else {
            Debug.Log("NORMAL STATE");
            Debug.Log("BlackGround: " + black_background.enabled);
            Debug.Log("Linterna: " + linterna.enabled);
            black_background.enabled = true;
            linterna.enabled = false;
        }
    }




}
