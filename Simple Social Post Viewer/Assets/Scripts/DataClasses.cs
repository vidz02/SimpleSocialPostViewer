[System.Serializable]
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
