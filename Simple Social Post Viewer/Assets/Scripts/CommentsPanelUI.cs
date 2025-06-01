using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class CommentsPanelUI : MonoBehaviour
{
    public static CommentsPanelUI Instance;
    public Transform commentsContent;
    public GameObject commentPrefab;
    public Button closeButton;
    private CanvasGroup canvasGroup;
    void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);       
        closeButton.onClick.AddListener(() => StartCoroutine(DeactivateWithDelay()));
        canvasGroup = GetComponent<CanvasGroup>();
    }
    IEnumerator DeactivateWithDelay()
    {
        // Add a simple animation effect before closing
        yield return new WaitForSeconds(closeButton.GetComponent<ButtonClickEffect>().animationDuration + 0.05f);
        gameObject.SetActive(false);
    }

    // Call this to open the popup with dummy comments
    public void ShowComments(string userName)
    {
        gameObject.SetActive(true);

        // Clear previous comments
        foreach (Transform child in commentsContent)
            Destroy(child.gameObject);

        // Add dummy comments
        for (int i = 1; i <= 4; i++)
        {
            GameObject commentGO = Instantiate(commentPrefab, commentsContent);
            commentGO.GetComponent<TMP_Text>().text = $"{userName} comment {i}";
        }
        
        // Basic Animation setup
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        canvasGroup.alpha = 0;
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * 4f;
            canvasGroup.alpha = Mathf.Lerp(0, 1, t);
            yield return null;
        }
        canvasGroup.alpha = 1;
    }
}