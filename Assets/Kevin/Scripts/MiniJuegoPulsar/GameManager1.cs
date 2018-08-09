using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour {

    bool Facil;
    bool Medio;
    bool Dificil;

    float tiempo;
    float tiempoBot;
    int pulsacionesPorSegundo;
    int pulsBot;

    void Start () {
		
	}
	
	void Update () {
        tiempoBot += Time.deltaTime;
        tiempo += Time.deltaTime;

        PulsacionesPorSegundoJugador();
    }


    //escena del tutorial
    public void PulsacionesPorSegundoJugador()
    {
        if (Input.GetKeyDown(KeyCode.Space) && tiempo <= 10)
        {
            pulsacionesPorSegundo++;

            if (pulsacionesPorSegundo >= 85)
            {
                Facil = true;
            }

            if (pulsacionesPorSegundo >= 95)
            {
                Medio = true;
            }

            if (pulsacionesPorSegundo >= 105)
            {
                Dificil = true;
            }
        }
    }


    //Esto se ejecutaria en otra escena, la del juego
    public void DificultadBot()
    {
        if (Facil == true)
        {
            if (tiempoBot >= 0.1176f)
            {
                pulsBot++;
                Debug.Log("Bot: " + pulsBot);
                tiempoBot = 0;
            }
        }

        else if (Medio == true)
        {
            if (tiempoBot >= 0.1052f)
            {
                pulsBot++;
                Debug.Log("Bot: " + pulsBot);
                tiempoBot = 0;
            }
        }

        else if (Dificil == true)
        {
            if (tiempoBot >= 0.0952f)
            {
                pulsBot++;
                Debug.Log("Bot: " + pulsBot);
                tiempoBot = 0;
            }
        }
    }

    void PulsarMuchasVeces()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pulsacionesPorSegundo++;
        }
    }

    public void Juego()
    {
        PulsarMuchasVeces();
        DificultadBot();
        Diferencia();
    }

    public void Diferencia()
    {
        if (pulsacionesPorSegundo - pulsBot >= 20)
        {
            Debug.Log("Has ganado");
        }

        else if(pulsBot - pulsacionesPorSegundo >= 20)
        {
            Debug.Log("Has perdido");
        }
    }
}
