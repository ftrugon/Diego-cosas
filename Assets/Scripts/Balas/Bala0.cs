using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala0 : BalaGenerica
{

    private Vector3 direccion;
    private float velocidad = 10f;

    void Start()
    {
        direccion = calcularDireccion();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(direccion);
    }

    Vector3 calcularDireccion()
    {
        return (Objetivo.transform.position - this.transform.position).normalized * velocidad * Time.deltaTime;
    }
}
