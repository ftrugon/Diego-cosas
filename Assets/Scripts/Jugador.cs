using System;
using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour
{

    public GameObject[] balas;

    public int vida = 20;


    private float speed = 40f;
    private new Rigidbody2D rigidbody2D;

    public Text mostrarVida;
    public Image imagenVida;
    public Image fondoVida;

    private float moveHorizontal = 0;
    private float moveVertical = 0;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Awake()
    {
        rigidbody2D = this.GetComponent<Rigidbody2D>();
        
    }
        
    private void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        if (vida <= 0)
        {
            this.gameObject.SetActive(false);
            mostrarVida.enabled = false;
            imagenVida.enabled = false;
            fondoVida.enabled = false;
        }

        Vector2 posicionRaton = cam.ScreenToWorldPoint(Input.mousePosition);


        if (Input.GetMouseButtonDown(0))
        {
            GameObject objeto = Instantiate(balas[0], this.transform.position, Quaternion.identity);
            BalaJugador bala = objeto.GetComponent<BalaJugador>();
            bala.Objetivo = posicionRaton;
        }

    }



    private void FixedUpdate()
    {
        float horizontalMovement = moveHorizontal * speed * Time.fixedDeltaTime;
        float verticalMovement = moveVertical * speed * Time.fixedDeltaTime;


        rigidbody2D.MovePosition(transform.position + new Vector3(horizontalMovement, verticalMovement, 0));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        quitarVida(collision.transform.tag);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Bala") { 
            collision.gameObject.SetActive(false);
            quitarVida(collision.tag);
        }
        if (collision.tag == "Rayo")
        {
            quitarVida(collision.tag);
        }
    }

    private void quitarVida(string tag)
    {
        
        if (tag == "Enemy" || tag == "Bala" || tag == "Rayo") { 
            vida--;
            mostrarVida.text = vida.ToString();
            ReducirAncho();
        }
    }

    void ReducirAncho()
    {
        // Obtener el RectTransform de la barra de vida
        RectTransform rectTransform = imagenVida.rectTransform;

        // Calcular el nuevo ancho basado en el porcentaje de reducción
        float nuevoAncho = 160f * (vida / 20f);

        // Asegurar que el nuevo ancho no sea menor que cero
        nuevoAncho = Mathf.Max(0f, nuevoAncho);

        // Establecer el nuevo tamaño
        rectTransform.sizeDelta = new Vector2(nuevoAncho, rectTransform.sizeDelta.y);
    }
}
