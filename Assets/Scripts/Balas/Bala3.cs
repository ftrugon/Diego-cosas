using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala3 : BalaGenerica
{
    private Vector3 direccion;
    private float velocidad = 20f;

    
    public override void onStart()
    {
        direccion = posicionObjetivo();
        
    }
    

    void Update()
    {

        if (this.transform.position == direccion)
        {
            direccion = posicionObjetivo();
        }
        else
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, direccion, velocidad * Time.deltaTime);
        }
    }


    Vector3 posicionObjetivo() 
    {
        return Objetivo.transform.position; 
    }
   
}
