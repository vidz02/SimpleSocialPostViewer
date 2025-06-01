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
    void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);       
        closeButton.onClick.AddListener(() => StartCoroutine(DeactivateWithDelay()));
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
    }
}