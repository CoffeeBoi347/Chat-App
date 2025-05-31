using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PostCreate : MonoBehaviour
{
    [Header("Tweet Holder Reference")]

    public TweetHolder tweetHolder;

    [Header("UI Elements")]

    public Button submitButton;
    public TMP_InputField inpField;

    [Header("Store Message")]

    public string messageToPost;

    private void Start()
    {
        messageToPost = string.Empty;
        inpField.text = string.Empty;
        if (tweetHolder == null)
        { 
            tweetHolder = FindObjectOfType<TweetHolder>();
        }

        if (submitButton != null)
        {
            submitButton.onClick.AddListener(OnSubmitButtonPressed);
        }
    }


    void OnSubmitButtonPressed()
    {
        messageToPost = inpField.text;
        inpField.text = string.Empty;
        tweetHolder.DisplayTweets(messageToPost);
    }
}