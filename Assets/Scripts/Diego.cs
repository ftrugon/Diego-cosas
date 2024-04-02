using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diego : MonoBehaviour
{

    public int vida = 100;

    public Text mostrarVida;
    public Image imagenVida;
    public Image fondoVida;
    public Text diegoSenorTal;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        quitarVida(collision.transform.tag);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Balajugador")
        {
            collision.gameObject.SetActive(false);
            quitarVida(collision.tag);
        }
    }

    private void Update()
    {
        if (vida <= 0)
        {
            this.gameObject.SetActive(false);
            mostrarVida.enabled = false;
            imagenVida.enabled = false;
            fondoVida.enabled = false;
            diegoSenorTal.enabled = false;
        }
    }

    private void quitarVida(string tag)
    {

        if (tag == "Balajugador")
        {
            vida--;
            mostrarVida.text = vida.ToString();
            ReducirAncho();
        }
    }

    void ReducirAncho()
    {
        RectTransform rectTransform = imagenVida.rectTransform;

        float nuevoAncho = 100f * (vida / 100f);

        nuevoAncho = Mathf.Max(0f, nuevoAncho);

        rectTransform.sizeDelta = new Vector2(nuevoAncho, rectTransform.sizeDelta.y);
    }

}
