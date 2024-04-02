using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala2 : BalaGenerica
{
    private float velocidad = 10f;

    void Update()
    {
        this.transform.Translate((Objetivo.transform.position - this.transform.position).normalized * velocidad * Time.deltaTime);
    }



}
