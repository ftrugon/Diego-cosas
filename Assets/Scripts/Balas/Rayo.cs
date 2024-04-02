using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rayo : MonoBehaviour
{

    private float velocidad = 20;
    private Rigidbody2D rayoRb;

    private void Awake()
    {
        rayoRb = GetComponent<Rigidbody2D>();
    }

    public void disparoRayo(Vector2 direction)
    {
        rayoRb.velocity = direction * velocidad;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.gameObject.SetActive(false);
    }


}
