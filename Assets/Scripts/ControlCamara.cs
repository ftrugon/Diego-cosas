using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour
{

    public GameObject jugador;
    public GameObject objetivo;
    private bool seHaPulsadoK;

    private const float velocidad = 10f;
    private const float multiplicador = 0.35f;
    

    void Update()
    {

        if (Input.GetMouseButtonDown(1)) {

            seHaPulsadoK = !seHaPulsadoK; 
        }

        Vector3 deberiaIrAqui = seHaPulsadoK ? acercarCamaraAlJugadorYEnemigo(jugador, objetivo) : acercarCamaraAlJugador(jugador);

        acercarDeAPoco(deberiaIrAqui);
    }


    void acercarDeAPoco(Vector3 deberiaIrAqui)
    {
        float velocidadDeAcercamiento = calcularVelocidad(deberiaIrAqui);
        this.transform.position = Vector3.MoveTowards(this.transform.position, deberiaIrAqui, velocidadDeAcercamiento);
    }

    float calcularVelocidad(Vector3 deberiaIrAqui)
    {
        float distancia = Vector3.Distance(this.transform.position, deberiaIrAqui);
        return velocidad * (1 + distancia * multiplicador) * Time.deltaTime;
    }

    Vector3 acercarCamaraAlJugador(GameObject jugador) 
    {
        return new Vector3(jugador.transform.position.x, jugador.transform.position.y, -20);
    }

    Vector3 acercarCamaraAlJugadorYEnemigo(GameObject jugador, GameObject enemigo)
    {
        Vector3 posicionMedia = (jugador.transform.position + objetivo.transform.position) / 2f;
        return new Vector3(posicionMedia.x, posicionMedia.y, transform.position.z);
    }
}
