using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public Canvas Canvas_Init;
    public Canvas Canvas_Credits;

    void Start()
    {
        Canvas_Init.gameObject.SetActive(true);
        Canvas_Credits.gameObject.SetActive(false);
    }

    public void Creditos()
    {
        Canvas_Init.gameObject.SetActive(false);
        Canvas_Credits.gameObject.SetActive(true);
    }

    public void Back_Creditos()
    {
        Canvas_Init.gameObject.SetActive(true);
        Canvas_Credits.gameObject.SetActive(false);
    }

    public void doExitGame()
    {
        Application.Quit();
    }

}
