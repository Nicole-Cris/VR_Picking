using System.Collections;
using UnityEngine;

public class Blinker : MonoBehaviour
{
    [Header("Blink settings")]
    public float blinkInterval = 0.6f; // piscar lento
    public int repeat = 3;             // piscar no máximo 3 vezes
    public Color highlightColor = Color.green; // cor final

    Renderer targetRenderer;
    SpriteRenderer targetSprite;
    Color originalColor;
    bool isBlinking = false;

    void Awake()
    {
        targetRenderer = GetComponentInChildren<Renderer>();
        targetSprite = GetComponentInChildren<SpriteRenderer>();

        if (targetRenderer != null)
            originalColor = targetRenderer.material.color;
        if (targetSprite != null)
            originalColor = targetSprite.color;
    }

    public void StartBlink()
    {
        if (isBlinking) return;
        StartCoroutine(BlinkCoroutine());
    }

    public void StopBlink()
    {
        StopAllCoroutines();
        isBlinking = false;
        SetColor(highlightColor); // mantém verde mesmo se parado
    }

    IEnumerator BlinkCoroutine()
    {
        isBlinking = true;

        for (int i = 0; i < repeat; i++)
        {
            // fica verde
            SetColor(highlightColor);
            yield return new WaitForSeconds(blinkInterval);

            // volta pra cor original
            SetColor(originalColor);
            yield return new WaitForSeconds(blinkInterval);
        }

        // DEPOIS DAS PISCADAS → FICA VERDE DE VEZ
        SetColor(highlightColor);

        isBlinking = false;
    }

    void SetColor(Color c)
    {
        if (targetRenderer != null)
            targetRenderer.material.color = c;

        if (targetSprite != null)
            targetSprite.color = c;
    }
}
