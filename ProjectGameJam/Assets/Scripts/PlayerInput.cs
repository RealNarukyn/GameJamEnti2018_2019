using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{

    SpriteRenderer black_background;
    SpriteRenderer linterna;
    Item item;
    public Text text;

    #region Variables
    private bool is_interacting = false;
    private bool is_lightOn = false;

    const int battery_max = 10;
    private int keys;
    private int batteries;

    private float time_gathered;
    const float time_max = 3;
    #endregion

    // Use this for initialization
    void Start()
    {
        black_background = GameObject.Find("Black_Background").GetComponent<SpriteRenderer>();
        linterna = GameObject.Find("Linterna").GetComponent<SpriteRenderer>();

        batteries = battery_max;
        //StartCoroutine(BatteryLife());

        keys = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Batteries Left: " + batteries + " / 10";

        if (Input.GetKey(KeyCode.Space) && batteries > 0)
        {
            black_background.enabled = false;
            linterna.enabled = true;
            is_lightOn = true;
            BatteryCountDown();
        }
        else
        {
            black_background.enabled = true;
            linterna.enabled = false;
            is_lightOn = false;
        }

        if (Input.GetKeyDown(KeyCode.F))
            is_interacting = true;
    }

    private void BatteryCountDown()
    {
        time_gathered += Time.deltaTime;
        if (time_gathered > time_max)
        {
            time_gathered = 0;
            batteries--;

            black_background.enabled = true;
            linterna.enabled = false;
            is_lightOn = false;
        }
    }

    private void GetItem(Collider2D col, int value)
    {
        value++;
        item = item = GameObject.Find(col.gameObject.name).GetComponent<Item>();
        item.Delete();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (is_interacting)
        {
            if (col.gameObject.name == "ItemKey")
                GetItem(col, keys);
            else if (col.gameObject.name == "Battery")
                GetItem(col, batteries);


            is_interacting = false;
        }
    }
}