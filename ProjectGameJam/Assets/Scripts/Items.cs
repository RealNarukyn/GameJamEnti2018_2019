using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Items : MonoBehaviour
{

    PlayerInput player;
    

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerInput>();
    }

    // Update is called once per frame
    void Update() { }

    public void Delete()
    {
        Destroy(this.gameObject);
    }
}