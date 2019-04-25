using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{

    SpriteRenderer black_background;
    SpriteRenderer linterna;
    Items item;
    Door door;
    public Text text_battery;
    public Text text_key;

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
     
        //door = GameObject.Find("Door").GetComponent<Door>();       

        batteries = battery_max;

        keys = 1;
    }


    // Update is called once per frame
    void Update()
    {
        DrawInfo();

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

    private void DrawInfo() {
        text_battery.text = batteries.ToString() + " / 10";
        text_key.text = keys.ToString();
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

    private void GetKey(Collider2D col)
    {
        keys++;

        item = item = GameObject.Find(col.gameObject.name).GetComponent<Items>();
        item.Delete();
    }

    private void GetBattery(Collider2D col)
    {
        batteries++;

        item = GameObject.Find(col.gameObject.name).GetComponent<Items>();
        item.Delete();
    }

    private void DoorAction(Collision2D col)
    {
        door = GameObject.Find(col.gameObject.name).GetComponent<Door>();

        if (keys > 0) {
            door.DoorAction();
            keys--;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (is_interacting)
        {
            if (col.gameObject.name == "ItemKey")
                GetKey(col);
            else if (col.gameObject.name == "Battery")
                GetBattery(col);

            is_interacting = false;
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (is_interacting)
        {
            if (
                col.gameObject.name == "Door1" || 
                col.gameObject.name == "Door2" ||
                col.gameObject.name == "Door3" 
                )
                DoorAction(col);

            is_interacting = false;
        }
    }

}