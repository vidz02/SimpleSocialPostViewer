using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PostCardUI : MonoBehaviour
{
    public Image profilePicImage;
    public TMP_Text userNameText;
    public TMP_Text contentText;
    public TMP_Text likeCountText;
    public Button likeButton;
    public Image likeIcon;
    public Button commentButton;

    private int postIndex;
    private Post postData;
    private bool isLiked;

    private CanvasGroup canvasGroup;

    public void Setup(Post post, int index)
    {
        if (post == null)
        {
            Debug.LogError("Post data is null!");
            return;
        }

        postData = post;
        postIndex = index;

        // Validate post data
        if (string.IsNullOrEmpty(post.username) || string.IsNullOrEmpty(post.content) || string.IsNullOrEmpty(post.profilePic))
        {
            Debug.LogError("Post data is incomplete!");
            return;
        }

        // Set up the UI elements with post data
        if (string.IsNullOrEmpty(post.profilePic))
        {
            Debug.LogWarning("Profile picture path is empty, using default sprite.");
            profilePicImage.sprite = Resources.Load<Sprite>("defaultProfilePic"); 
        }
        else
        {
            Sprite profileSprite = Resources.Load<Sprite>(post.profilePic);
            if (profileSprite != null)
                profilePicImage.sprite = profileSprite;
            else
            {
                Debug.LogWarning($"Profile picture sprite not found at path: {post.profilePic}");
                profilePicImage.sprite = Resources.Load<Sprite>("defaultProfilePic"); 
            }
        }

        userNameText.text = post.username;
        contentText.text = post.content;
        likeCountText.text = post.likes.ToString();

        // Load liked state from PlayerPrefs
        isLiked = PlayerPrefs.GetInt($"Liked_{postIndex}", 0) == 1;
        UpdateLikeVisual();

        // Add listeners for buttons
        likeButton.onClick.RemoveListener(ToggleLike);
        likeButton.onClick.AddListener(ToggleLike);

        commentButton.onClick.RemoveListener(OpenComments);
        commentButton.onClick.AddListener(OpenComments);

        // Basic Animation setup
        canvasGroup = GetComponent<CanvasGroup>();
        StartCoroutine(FadeIn()); 
    }

    IEnumerator FadeIn()
    {
        canvasGroup.alpha = 0;
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * 2f;
            canvasGroup.alpha = Mathf.Lerp(0, 1, t);
            yield return null;
        }
        canvasGroup.alpha = 1;
    }

    void ToggleLike()
    {
        isLiked = !isLiked;
        PlayerPrefs.SetInt($"Liked_{postIndex}", isLiked ? 1 : 0);
        int likes = int.Parse(likeCountText.text);
        likes += isLiked ? 1 : -1;
        likeCountText.text = likes.ToString();
        UpdateLikeVisual();
    }

    void UpdateLikeVisual()
    {
        likeIcon.color = isLiked ? Color.red : Color.gray;
    }
    
    void OpenComments()
    {
        CommentsPanelUI.Instance.ShowComments(postData.username);
    }
}
