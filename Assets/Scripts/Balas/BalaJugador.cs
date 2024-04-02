using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaJugador : MonoBehaviour
{
    public Vector3 Objetivo;
    private Vector3 direccion;
    private float velocidad = 30f;

    void Start()
    {
        direccion = calcularDireccion();
    }

    public void Update()
    {
        this.transform.Translate(direccion);
    }

    Vector3 calcularDireccion()
    {
        return (Objetivo - this.transform.position).normalized * velocidad * Time.deltaTime;
    }
}
