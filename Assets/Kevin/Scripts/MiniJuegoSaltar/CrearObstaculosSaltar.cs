using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearObstaculosSaltar : MonoBehaviour {

    public Transform prefab;
    public Transform coordenadas;

    public void Instacia()
    {
        Instantiate(prefab, coordenadas.position, Quaternion.identity);
    }
}

