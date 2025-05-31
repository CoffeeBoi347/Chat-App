using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LikeButton : MonoBehaviour
{
    public string tweetID;
    public string tweetIDNo;
    public bool setRandomNumber = false;
    public Button _likeButton;
    public TMP_Text likesTxt;
    public TMP_Text dislikesTxt;
    public int getLikesCount;
    public int getDislikesCount;
    public int likesCount;
    public int dislikeCount;
    public Sprite heartButton;
    public Sprite heartBreakButton;
    public Button _dislikeButton;

    private void Start()
    {
        if (setRandomNumber == true)
        {
            int randomVal = Random.Range(0, 9998);
            int randomDislike = Random.Range(0, 999);
            likesCount = randomVal;
            likesTxt.text = likesCount.ToString();
            dislikeCount = randomDislike;
            dislikesTxt.text = dislikeCount.ToString();
        }

        if (!setRandomNumber)
        {
            likesCount = PlayerPrefs.GetInt($"Like_{tweetID}");
            dislikeCount = PlayerPrefs.GetInt($"Dislike_{tweetID}");

            likesTxt.text = likesCount.ToString();
            dislikesTxt.text = dislikeCount.ToString();
        }


        _likeButton.onClick.AddListener(IncreaseLikes);
        _dislikeButton.onClick.AddListener(DecreaseLikes);
    }

    void IncreaseLikes()
    {
        _likeButton.gameObject.GetComponent<Image>().sprite = heartButton;
        likesCount++;
        PlayerPrefs.SetInt($"Like_{tweetID}", likesCount);
        PlayerPrefs.Save();

        getLikesCount = PlayerPrefs.GetInt($"Like_{tweetID}");
        likesTxt.text = getLikesCount.ToString();
        _likeButton.interactable = false;
    }

    void DecreaseLikes()
    {
        _dislikeButton.gameObject.GetComponent<Image>().sprite = heartBreakButton;
        _dislikeButton.gameObject.GetComponent<Image>().transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 1f, transform.localScale.z);
        dislikeCount++;
        PlayerPrefs.SetInt($"Dislike_{tweetID}", dislikeCount);
        PlayerPrefs.Save();

        getDislikesCount = PlayerPrefs.GetInt($"Dislike_{tweetID}");
        dislikesTxt.text = getDislikesCount.ToString();
        _dislikeButton.interactable = false;
    }
}