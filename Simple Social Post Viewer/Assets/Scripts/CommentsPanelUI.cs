using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
        closeButton.onClick.AddListener(() => gameObject.SetActive(false));
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