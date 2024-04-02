using UnityEngine;

public class Enemigos : MonoBehaviour
{
    public GameObject jugador;
    private float velocidadOrbita = 100f;

    public GameObject[] balas;
    private float tiempo;


    void Update()
    {
        
        Vector3 directionToTarget = jugador.transform.position - transform.position;

       
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget, Vector3.forward);

        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, velocidadOrbita * Time.deltaTime);

        {
            tiempo += Time.deltaTime;
            if (tiempo > 0.5)
            {
                tiempo = 0;
                crearBala();
            }
        }

    }

    void crearBala()
    {
        GameObject objeto = Instantiate(balas[Random.RandomRange(0, balas.Length)], this.transform.position, Quaternion.identity);
        BalaGenerica bala = objeto.GetComponent<BalaGenerica>();
        bala.Objetivo = jugador;
        bala.onStart();
    }
}