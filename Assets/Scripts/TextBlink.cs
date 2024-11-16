using System.Collections;
using UnityEngine;

public class TextBlink : MonoBehaviour
{
    public float blinkSpeed = 1f; // Velocidad de parpadeo
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Obtén el SpriteRenderer al inicio
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("No se encontró un SpriteRenderer en " + gameObject.name);
        }

        // Comienza la corrutina de parpadeo
        StartCoroutine(Blink());
    }

    private IEnumerator Blink()
    {
        while (true)
        {
            // Alternar entre visible e invisible
            spriteRenderer.color = new Color(1f, 1f, 1f, 0f); // Invisible
            yield return new WaitForSeconds(1f / blinkSpeed);

            spriteRenderer.color = new Color(1f, 1f, 1f, 1f); // Visible
            yield return new WaitForSeconds(1f / blinkSpeed);
        }
    }

    public void SetFastBlink()
    {
        // Cambia la velocidad de parpadeo a rápida
        blinkSpeed = 7f;
    }
}