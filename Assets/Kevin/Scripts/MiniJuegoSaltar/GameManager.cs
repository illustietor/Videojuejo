using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public CrearObstaculosSaltar crearObstaculos;
    public Trigger trigger;

    public float tiempo;

    void Cubos()
    {
        tiempo += Time.deltaTime;

        if (trigger.puntuacion <= 5)
        {
            if (tiempo >= 4)
            {
                crearObstaculos.Instacia();
                tiempo = 0;
            }
        }

        if (trigger.puntuacion > 5 && trigger.puntuacion <= 10)
        {
            if (tiempo >= 3)
            {
                crearObstaculos.Instacia();
                tiempo = 0;
            }
        }

        if (trigger.puntuacion > 10 && trigger.puntuacion <= 15)
        {
            if (tiempo >= 2)
            {
                crearObstaculos.Instacia();
                tiempo = 0;
            }
        }
    }

	void Start () {
		
	}
	
	void Update () {
        Cubos();
	}
}
