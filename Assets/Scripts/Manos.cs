using System.Collections;
using UnityEngine;

public class Manos : MonoBehaviour
{
    [SerializeField] private GameObject jugador;
    [SerializeField] private Transform[] waypoitns;
    public GameObject[] Rayos;
    private int waypointActual;
    private float velocidad = 20f;
    private float distanciaMinima = 0.1f; // Distancia mínima para considerar que se ha alcanzado un waypoint
    private bool estaEnEspera;

    void Update()
    {

        
        if (Vector2.Distance(transform.position, waypoitns[waypointActual].position) > distanciaMinima)
        {
            // Si no ha alcanzado el waypoint actual, mueve hacia él
            transform.position = Vector2.MoveTowards(transform.position, waypoitns[waypointActual].position, velocidad * Time.deltaTime);
            mirarJugador();
        }
        else if (!estaEnEspera)
        {
            // Si ha alcanzado el waypoint actual, espera y luego avanza al siguiente
            StartCoroutine(Espera());
        }
    }

    IEnumerator Espera()
    {
        estaEnEspera = true;
        dispararRayo();
        yield return new WaitForSeconds(2f); // Tiempo de espera
        waypointActual = (waypointActual + 1) % waypoitns.Length; // Avanzar al siguiente waypoint
        estaEnEspera = false;
    }

    void mirarJugador()
    {
        Vector2 direccion = jugador.transform.position - transform.position;
        transform.up = Vector2.MoveTowards(transform.up,direccion, 4 * Time.deltaTime);
    }

    void dispararRayo()
    {
        GameObject objeto = Instantiate(Rayos[0], transform.position, transform.rotation);
        Rayo rayo = objeto.GetComponent<Rayo>();

        rayo.disparoRayo(transform.up);

    }
}

