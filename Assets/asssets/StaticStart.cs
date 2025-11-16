using UnityEngine;

public class StaticFadeController : MonoBehaviour
{
    public Material staticMaterial;       // Your static FX material
    public float fadeDuration = 3f;       // Time to fully fade out
    public MonoBehaviour playerMovement;  // Your movement script reference

    private void Start()
    {
        // Disable player movement first
        if (playerMovement != null)
            playerMovement.enabled = false;

        // Set static fully visible
        staticMaterial.SetFloat("_StaticOpacity", 1f);

        // Start fade-out coroutine
        StartCoroutine(FadeStatic());
    }

    private System.Collections.IEnumerator FadeStatic()
    {
        float startOpacity = 1f;
        float endOpacity = 0f;
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;

            float t = elapsed / fadeDuration;
            float opacity = Mathf.Lerp(startOpacity, endOpacity, t);

            staticMaterial.SetFloat("_StaticOpacity", opacity);

            yield return null;
        }

        // Make sure it hits zero
        staticMaterial.SetFloat("_StaticOpacity", 0f);

        // Re-enable movement only when the effect is gone
        if (playerMovement != null)
            playerMovement.enabled = true;
    }
}
