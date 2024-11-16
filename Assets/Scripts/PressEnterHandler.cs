using System.Collections; // Necesario para IEnumerator
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class PressEnterHandler : MonoBehaviour
{
    public TextBlink textBlink; // Referencia al script de parpadeo
    public AudioClip sfx; // Sonido al presionar Enter
    private AudioSource audioSource;

    void Start()
    {
        // Agregar un componente de AudioSource automáticamente
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        // Detectar la tecla Enter
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(OnPressEnter()); // Iniciar la rutina para manejar la lógica
        }
    }

    private IEnumerator OnPressEnter()
    {
        // Reproducir SFX al presionar Enter
        if (sfx != null)
        {
            audioSource.PlayOneShot(sfx);
        }

        // Cambiar a parpadeo rápido
        textBlink.SetFastBlink();

        // Esperar 2 segundos antes de cambiar de escena
        yield return new WaitForSeconds(2f);

        // Cambiar a la escena del juego
        SceneManager.LoadScene("ganaste");
    }
}