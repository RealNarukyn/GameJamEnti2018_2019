using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Camara : MonoBehaviour {

    private Transform posicionJugador;

    public float velocidad = 0.125f;
    
    public Canvas canvasPause;
    public GameObject Jugador;

    // Use this for initialization
    void Start()
    {
        canvasPause.gameObject.SetActive(false);
        Jugador.SetActive(true);
        //Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

        /*
        jugadorPosX = jugador.transform.position.x;
        jugadorPosY = jugador.transform.position.y;
        gameObject.transform.position = new Vector3(jugadorPosX, jugadorPosY + 1.5f, gameObject.transform.position.z);
        */
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                canvasPause.gameObject.SetActive(true);
                Jugador.SetActive(false);

            }
            else
            {
                Time.timeScale = 1;
                canvasPause.gameObject.SetActive(false);
                Jugador.SetActive(true);
            }
        }
    }

    public void NextScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    public void Continuar()
    {
        Time.timeScale = 1;
        canvasPause.gameObject.SetActive(false);
        Jugador.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }
}



