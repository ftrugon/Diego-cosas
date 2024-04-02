using UnityEngine;

public class Partida : MonoBehaviour
{

    public Canvas uis;
    public Jugador jugador;

    private float tiempo = 30;
    private float tiempoTranscurrido = 0;
    private bool partidaActiva = false;
    private bool haSobrevivido = false;

    private Diego diego;


    // Start is called before the first frame update
    void Start()
    {
        uis.transform.GetChild(0).gameObject.SetActive(false);
        uis.transform.GetChild(1).gameObject.SetActive(false);
        uis.transform.GetChild(2).gameObject.SetActive(true);
        uis.transform.GetChild(3).gameObject.SetActive(false);
        uis.transform.GetChild(4).gameObject.SetActive(false);

        desactivarTodo();

        diego = this.transform.GetChild(0).GetComponent<Diego>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoTranscurrido > 5 && !partidaActiva) {
            uis.transform.GetChild(2).gameObject.SetActive(false);
            uis.transform.GetChild(0).gameObject.SetActive(true);
            activarTodo();
            partidaActiva = true;
        }

        if (diego.vida <= 0)
        {
            uis.transform.GetChild(4).gameObject.SetActive(true);
            uis.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
            tiempo -= Time.deltaTime;
            if (tiempo <= 0) { haSobrevivido = true; };
        }

        if (jugador.vida <= 0)
        {
            desactivarTodo();
            uis.transform.GetChild(0).gameObject.SetActive(false);
            uis.transform.GetChild(4).gameObject.SetActive(false);
            uis.transform.GetChild(1).gameObject.SetActive(true);
        }

        if (haSobrevivido)
        {
            desactivarTodo();
            uis.transform.GetChild(0).gameObject.SetActive(false);
            uis.transform.GetChild(4).gameObject.SetActive(false);
            uis.transform.GetChild(3).gameObject.SetActive(true);
        }
        tiempoTranscurrido += Time.deltaTime;
    }

    private void desactivarTodo()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(1).gameObject.SetActive(false);
        this.transform.GetChild(2).gameObject.SetActive(false);
        this.transform.GetChild(3).gameObject.SetActive(false);
        this.transform.GetChild(4).gameObject.SetActive(false);
    }

    private void activarTodo()
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
        this.transform.GetChild(1).gameObject.SetActive(true);
        this.transform.GetChild(2).gameObject.SetActive(true);
        this.transform.GetChild(3).gameObject.SetActive(true);
        this.transform.GetChild(4).gameObject.SetActive(true);
    }
}
