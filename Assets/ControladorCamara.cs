using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCamara : MonoBehaviour
{
    public GameObject jugador;
    public GameObject circulo;
    private Vector3 posRelativa = Vector3.zero; // Inicializa posRelativa a Vector3.zero

    void LateUpdate()
    {
        // Calcula la posición media entre el jugador y el círculo
        Vector3 posicionMedia = (jugador.transform.position + circulo.transform.position) / 2f;

        // Ajusta la posición de la cámara
        transform.position = new Vector3(posicionMedia.x, posicionMedia.y, transform.position.z);
    }
}