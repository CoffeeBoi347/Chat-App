using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TweetHolder : MonoBehaviour
{
    public List<string> messages = new List<string>();
    public TMP_Text playerNameTxt;
    public TMP_Text followersTxt;
    public Transform msgParent;
    public GameObject msgObj;
    public int followers;
    public bool canInstantiate = false;

    private void Start()
    {
        followersTxt.text = $"{followers} Followers";
        LoadTweets();
        playerNameTxt.text = GameManager.instance.playerName;
    }

    public void DisplayTweets(string messageVal)
    {
        if (!string.IsNullOrEmpty(messageVal))
        {
            messages.Insert(0, messageVal);
            SaveMessages();
        }

        foreach (Transform obj in msgParent)
        {
            Destroy(obj.gameObject);
        }

        foreach (var msg in messages)
        {
            GameObject msgBox = Instantiate(msgObj, msgParent.transform);
            var getTxt = msgBox.GetComponentsInChildren<TMP_Text>();
            TMP_Text nameTxt = getTxt[0];
            TMP_Text messageTxt = getTxt[1];
            nameTxt.text = GameManager.instance.playerName;
            messageTxt.text = msg;
        }
    }

    void SaveMessages()
    {
        string msg = string.Join("|", messages);
        PlayerPrefs.SetString("SaveTweets", msg);
        PlayerPrefs.Save();
    }

    void LoadTweets()
    {
        var accessPlayerData = PlayerPrefs.GetString("SaveTweets");
        messages = new List<string>(accessPlayerData.Split("|"));
        DisplayTweets("");
    }
}