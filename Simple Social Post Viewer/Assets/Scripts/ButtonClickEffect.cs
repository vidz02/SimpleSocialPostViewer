using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonClickEffect : MonoBehaviour
{
    public Button button;
    public float scaleFactor = 1.2f;
    public float animationDuration = 0.1f;

    private Vector3 originalScale;

    private void Awake()
    {
        if (button == null)
            button = GetComponent<Button>();
        originalScale = button.transform.localScale;
        button.onClick.AddListener(AnimateButton);
    }

    void AnimateButton()
    {
        StopAllCoroutines();
        StartCoroutine(ScaleButton());
    }

    IEnumerator ScaleButton()
    {
        // Scale up
        float elapsed = 0f;
        while (elapsed < animationDuration)
        {
            button.transform.localScale = Vector3.Lerp(originalScale, originalScale * scaleFactor, elapsed / animationDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        button.transform.localScale = originalScale * scaleFactor;

        // Scale back down
        elapsed = 0f;
        while (elapsed < animationDuration)
        {
            button.transform.localScale = Vector3.Lerp(originalScale * scaleFactor, originalScale, elapsed / animationDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        button.transform.localScale = originalScale;
    }
}
