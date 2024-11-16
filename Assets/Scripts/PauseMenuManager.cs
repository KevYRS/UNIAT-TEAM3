using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenuCanvas; // Canvas del menú de pausa
    private bool isPaused = false;

    void Update()
    {
        // Alternar el menú de pausa con la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
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
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f; // Asegurarse de que el tiempo está normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reiniciar la escena actual
    }

    public void GoToTitleScreen()
    {
        Time.timeScale = 1f; // Asegurarse de que el tiempo está normal
        SceneManager.LoadScene("TitleScreen"); // Cambiar a la escena de título
    }
}