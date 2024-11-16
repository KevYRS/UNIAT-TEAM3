using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenuCanvas; // Canvas del menú de pausa
    private bool isPaused = false;

    public AudioSource audioSource;

    AudioSource sonidos;
    public AudioClip pausa;


    void Start ()
    {
        audioSource.Play();
        sonidos = GetComponent<AudioSource>();
    }
    void Update()
    {
        // Alternar el menú de pausa con la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
                audioSource.Play();
            }

            else
            {
                PauseGame();
            audioSource.Stop();
               sonidos.PlayOneShot(pausa);
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f; // Pausar el tiempo del juego
        

    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f; // Reanudar el tiempo del juego
        audioSource.Play();
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f; // Asegurarse de que el tiempo está normal
        SceneManager.LoadScene("SampleScene"); // Reiniciar la escena actual
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