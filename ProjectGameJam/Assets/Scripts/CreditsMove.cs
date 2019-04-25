using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMove : MonoBehaviour {

    private Transform credits;
    //const float next_move = 0.1f;
    //float move ;
    //const float init_pos = -2100;
    //const float end_pos = 2100;
    float i;
    Vector2 credits_vector2;


    // Use this for initialization
    void Start () {
        credits = GetComponent<Transform>();
        credits_vector2 = credits.position;
        i = credits.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (i > -700)
        {
            credits.position = new Vector2(credits_vector2.x, i);
            i++;
        }
        if (i > 2100)
        {
            print(i);
            credits.position = new Vector2(credits_vector2.x, credits_vector2.y);
        }
    }
}
