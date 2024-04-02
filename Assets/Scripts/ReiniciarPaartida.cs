using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarPaartida : MonoBehaviour
{
    public void LoadScene(string escena)
    {
        SceneManager.LoadScene(escena);
    }

    public void salir()
    {
        Application.Quit();
    }
}
