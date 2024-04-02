using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala1 : BalaGenerica
{
    private Vector3 direccion;
    private float velocidad = 5f;

    // Start is called before the first frame update

    public override void onStart()
    {
        direccion = calcularDireccion();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(direccion);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Pared")
        {
            direccion = calcularDireccion();
        }
    }

    Vector3 calcularDireccion()
    {
        return (Objetivo.transform.position - this.transform.position).normalized * velocidad * Time.deltaTime;
    }


}
