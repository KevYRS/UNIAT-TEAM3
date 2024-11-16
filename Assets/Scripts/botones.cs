using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class botones : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //RestartLevel();
        //Salir();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void RestartLevel()
    {
        Time.timeScale = 1f; // Asegurarse de que el tiempo está normal
        SceneManager.LoadScene("SampleScene"); // Reiniciar la escena actual
        Debug.Log("volver a jugar");
    }

    public void GoToTitleScreen()
    {
        Time.timeScale = 1f; // Asegurarse de que el tiempo está normal
        SceneManager.LoadScene("TitleScreen"); // Cambiar a la escena de título
    }


    public void Salir()
    {

        Application.Quit();
        Debug.Log("salio del juego");
    }
}
