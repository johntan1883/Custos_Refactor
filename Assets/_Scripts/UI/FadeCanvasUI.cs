using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class FadeCanvasUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textObject;      // Reference to the TextMeshPro component
    [SerializeField] private Image panelObject;       // Reference to the Panel's Image component
    [SerializeField] private float fadeDuration = 2f; // Duration of the fade-out effect in seconds
    [SerializeField] private float delayBeforeFade = 3f; // Delay before starting the fade

    private float fadeTimer;

    void Start()
    {
        // Start the coroutine that handles the delay and fade
        StartCoroutine(FadeAfterDelay());
    }

    private IEnumerator FadeAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayBeforeFade);

        // Initialize the timer
        fadeTimer = fadeDuration;

        // Start fading
        while (fadeTimer > 0)
        {
            // Reduce the timer over time
            fadeTimer -= Time.deltaTime;

            // Calculate the new alpha value
            float alpha = Mathf.Clamp01(fadeTimer / fadeDuration);

            // Apply the new alpha value to the text color
            Color textColor = textObject.color;
            textColor.a = alpha;
            textObject.color = textColor;

            // Apply the new alpha value to the panel color
            Color panelColor = panelObject.color;
            panelColor.a = alpha;
            panelObject.color = panelColor;

            // Wait for the next frame
            yield return null;
        }

        // Destroy the objects when fully transparent
        Destroy(textObject.gameObject);
        Destroy(panelObject.gameObject);
    }
}
