using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoQueCaen : MonoBehaviour {
    GameObject cubo;

    float tiempo;

    void Objetos()
    {
        cubo = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubo.AddComponent<Rigidbody>();
        cubo.GetComponent<BoxCollider>().isTrigger = true;
        cubo.transform.position = new Vector2(Random.Range(-10, 10), 8);
        cubo.tag = "Cubo";
    }

	void Start () {

    }

	void Update () {
        tiempo += Time.deltaTime;

        if (tiempo >= 1)
        {
            Objetos();
            tiempo = 0;
        }
	}
}
