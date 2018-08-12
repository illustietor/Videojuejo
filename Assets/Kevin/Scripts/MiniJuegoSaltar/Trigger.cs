using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

    public CrearObstaculosSaltar crearObstaculos;

    public int puntuacion = 0;

    void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        puntuacion++;
        Destroy(other.gameObject);

    }
}
