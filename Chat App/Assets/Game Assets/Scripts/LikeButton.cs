using TMPro;
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


        _likeButton.onClick.AddListener(IncreaseLikes);
        _dislikeButton.onClick.AddListener(DecreaseLikes);
    }

    void IncreaseLikes()
    {
        _likeButton.gameObject.GetComponent<Image>().sprite = heartButton;
        likesCount++;
        PlayerPrefs.SetInt("LikesVal", likesCount);
        PlayerPrefs.Save();

        getLikesCount = PlayerPrefs.GetInt("LikesVal");
        likesTxt.text = getLikesCount.ToString();
        _likeButton.interactable = false;
    }

    void DecreaseLikes()
    {
        dislikeCount++;
        PlayerPrefs.SetInt("DislikeVal", dislikeCount);
        PlayerPrefs.Save();

        getDislikesCount = PlayerPrefs.GetInt("DislikeVal");
        dislikesTxt.text = getDislikesCount.ToString();
        _dislikeButton.interactable = false;
    }
}