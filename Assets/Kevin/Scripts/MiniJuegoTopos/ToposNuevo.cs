using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToposNuevo : MonoBehaviour {

    public enum Topos
    {
        topoArriba,
        topoAbajo,
        topoDerecha,
        topoIzquierda
    }

    public Image[] topo;
    public Sprite topoFuera, topoGolpeado, topoEscondido;

    public int puntuacion;
    public int numeroPartidas;

    public float tiempoMinimoAparecer, tiempoMaximoAparecer;
    public float tiempoMinimoDesaparecer , tiempoMaximoDesaparecer;
    public float tiempoMaximoGolpeado;
    public float tiempoTotal;
    float[] tiempoRandomAparecer;
    float[] tiempoRandomDesaparecer;
    float[] tiempoActual;

	// Use this for initialization
	void Start () {
        //coroutineTopoArriba = StartCoroutine(AparecerYDesaparecerTopo(topoArriba));
        //coroutineTopoAbajo = StartCoroutine(AparecerYDesaparecerTopo(topoAbajo));
        //coroutineTopoDerecha = StartCoroutine(AparecerYDesaparecerTopo(topoDerecha));
        //coroutineTopoIzquierda = StartCoroutine(AparecerYDesaparecerTopo(topoIzquierda));
        tiempoRandomAparecer = new float[4];
        tiempoRandomDesaparecer = new float[4];
        tiempoActual = new float[4];
        for (int i = 0; i < tiempoRandomAparecer.Length; i++)
        {
            CambiarTiempoRandomTopo(i);
        }
    }

    void FinalJuego()
    {
        if (tiempoTotal > 30f && puntuacion < 30)
        {
            Time.timeScale = 0;
            topo[0].sprite = topoEscondido;
            topo[1].sprite = topoEscondido;
            topo[2].sprite = topoEscondido;
            topo[3].sprite = topoEscondido;
        }

        if (tiempoTotal < 30f && puntuacion >= 30)
        {
            Time.timeScale = 0;
            topo[0].sprite = topoGolpeado;
            topo[1].sprite = topoGolpeado;
            topo[2].sprite = topoGolpeado;
            topo[3].sprite = topoGolpeado;

            RestartJuego();
        }
    }

    public void RestartJuego()
    {
        StartCoroutine(EsperarVolverIniciarJuego());
    }


    private void CambiarTiempoRandomTopo(int topo){
        tiempoRandomAparecer[topo] = Random.Range(tiempoMinimoAparecer, tiempoMaximoAparecer);
        tiempoRandomDesaparecer[topo] = Random.Range(tiempoMinimoDesaparecer, tiempoMaximoDesaparecer);

    }
	
	// Update is called once per frame
	void Update () {
        tiempoTotal += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.UpArrow) && topo[(int)Topos.topoArriba].sprite == topoFuera)
        {
            Debug.Log("He golpeado al topo de arriba");
            topo[0].sprite = topoGolpeado;
            tiempoActual[0] = 0f;
            CambiarTiempoRandomTopo(0);
            puntuacion++;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && topo[(int)Topos.topoAbajo].sprite == topoFuera)
        {
            Debug.Log("He golpeado al topo de abajo");
            topo[1].sprite = topoGolpeado;
            tiempoActual[1] = 0f;
            CambiarTiempoRandomTopo(1);
            puntuacion++;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && topo[(int)Topos.topoDerecha].sprite == topoFuera)
        {
            Debug.Log("He golpeado al topo de derecha");
            topo[2].sprite = topoGolpeado;
            tiempoActual[2] = 0f;
            CambiarTiempoRandomTopo(2);
            puntuacion++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && topo[(int)Topos.topoIzquierda].sprite == topoFuera)
        {
            Debug.Log("He golpeado al topo de izquierda");
            topo[3].sprite = topoGolpeado;
            tiempoActual[3] = 0f;
            CambiarTiempoRandomTopo(3);
            puntuacion++;
        }

        for (int i = 0; i < tiempoActual.Length; i++)
        {
            tiempoActual[i] += Time.deltaTime;
            if (topo[i].sprite == topoEscondido && tiempoActual[i] > tiempoRandomAparecer[i])
            {
                topo[i].sprite = topoFuera;
                tiempoActual[i] = 0;
            }
            else if (topo[i].sprite == topoFuera && tiempoActual[i] > tiempoRandomDesaparecer[i])
            {
                topo[i].sprite = topoEscondido;
                tiempoActual[i] = 0;
            }
            else if (topo[i].sprite == topoGolpeado && tiempoActual[i] > tiempoMaximoGolpeado)
            {
                topo[i].sprite = topoEscondido;
                tiempoActual[i] = 0;
            }
        }
        FinalJuego();
    }

    IEnumerator EsperarVolverIniciarJuego()
    {
        Debug.Log("La corutine se ejecuta");
        yield return new WaitForSecondsRealtime(3f);
        Debug.Log("Esto deberia funcionar");
        puntuacion = 0;
        tiempoTotal = 0;
        for (int i = 0; i < tiempoActual.Length; i++)
        {
            tiempoActual[i] = 0;
        }
        Time.timeScale = 1;
    }

    //IEnumerator AparecerYDesaparecerTopo(Image topo)
    //{
    //    topo.sprite = topoEscondido;
    //    while (true) {
    //        if (topo == topoArriba) Debug.Log("TopoArriba y me ejecuto");
    //        yield return new WaitForSeconds(Random.Range(4f, 7f));
    //        topo.sprite = topoFuera;
    //        yield return new WaitForSeconds(Random.Range(4f, 7f));
    //        topo.sprite = topoEscondido;
    //    }
    //}

    //IEnumerator TopoGolpeado(Image topo)
    //{
    //    topo.sprite = topoGolpeado;
    //    Debug.Log("Coroutina parada");
    //    yield return new WaitForSeconds(1f);
    //    StartCoroutine(AparecerYDesaparecerTopo(topo));
    //}
}
