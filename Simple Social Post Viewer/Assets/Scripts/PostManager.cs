using UnityEngine;

public class PostManager : MonoBehaviour
{
    public GameObject postCardPrefab;
    public Transform contentParent;
    void Start()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("postData");
        if (jsonFile == null)
        {
            Debug.LogError("postData.json not found!");
            return;
        }

        PostList postList = JsonUtility.FromJson<PostList>(jsonFile.text);

        for (int i = 0; i < postList.posts.Length; i++)
        {
            GameObject postGO = Instantiate(postCardPrefab, contentParent);
            PostCardUI card = postGO.GetComponent<PostCardUI>();
            card.Setup(postList.posts[i], i);
        }
    }
}
