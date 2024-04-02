using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{

    private float tiempo = 30;

    public Text texto;


    // Update is called once per frame
    void Update()
    {
        tiempo -= Time.deltaTime;
        texto.text = tiempo.ToString();
    }
}
