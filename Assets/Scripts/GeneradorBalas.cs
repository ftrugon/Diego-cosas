using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GeneradorBalas : MonoBehaviour
{

    public GameObject[] balas;
    public GameObject diego;
    public GameObject jugador;

    private float tiempo;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        if (tiempo > 3)
        {
            tiempo = 0;
            crearBala();
        }
    }

    void crearBala()
    {
        GameObject objeto =  Instantiate(balas[Random.RandomRange(0, balas.Length)],diego.transform.position,Quaternion.identity);
        BalaGenerica bala = objeto.GetComponent<BalaGenerica>();
        bala.Objetivo = jugador;
        bala.onStart();
    }
}
