using UnityEngine;
using UnityEngine.UI;
using TMPro; // For TextMeshPro
using System;

[Serializable]
public class Post
{
    public string username;
    public string profilePic;
    public string content;
    public int likes;
}

[System.Serializable]
public class PostList
{
    public Post[] posts;
}


public class PostLoader : MonoBehaviour
{
    public Image profilePicImage;
    public TMP_Text userNameText;
    public TMP_Text contentText;
    public TMP_Text likeCountText;

    Post[] posts;

    private void Start()
    {
        LoadPost();
    }

    void LoadPost()
    {
        // Load JSON from Resources
        TextAsset jsonFile = Resources.Load<TextAsset>("postData");
        if (jsonFile == null)
        {
            Debug.LogError("postData.json not found in Resources!");
            return;
        }

        PostList postList = JsonUtility.FromJson<PostList>(jsonFile.text);
        posts = postList.posts;
        setupPost();
    }

    private void setupPost()
    {
        if (posts == null || posts.Length == 0)
        {
            Debug.LogError("No posts found in postData.json!");
            return;
        }

        // Select a random post from the array
        int randomIndex = UnityEngine.Random.Range(0, posts.Length);
        Post post = posts[randomIndex];

        if (post == null)
        {
            Debug.LogError("Post data is null!");
            return;
        }

        // Validate post data
        if (string.IsNullOrEmpty(post.username) || string.IsNullOrEmpty(post.content) || string.IsNullOrEmpty(post.profilePic))
        {
            Debug.LogError("Post data is incomplete!");
            return;
        }

        // Set UI elements
        userNameText.text = post.username;
        contentText.text = post.content;
        likeCountText.text = post.likes.ToString();

        // Load profile picture sprite from Resources
        Sprite profileSprite = Resources.Load<Sprite>(post.profilePic);
        if (profileSprite == null)
        {
            Debug.LogWarning("Profile picture '" + post.profilePic + "' not found, using default.");
        }
        else
        {
            profilePicImage.sprite = profileSprite;
        }
    }
}
