using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProfileView : MonoBehaviour
{
    public TMP_Text followersTxt;
    public int followers;
    public List<string> randomMessages = new List<string>();
    public HomePage pageHome;
    public static ProfileView instance;
    public string namePlayer;
    public TMP_Text viewPlayerName;
    public GameObject messageBoxObj;
    public Transform messageBoxParent;
    public string playerLoad;

    [Header("First Text")]

    public GameObject firstMsgObj;

    private string playerNameHolder;
    private string messageHolder;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateText(string playerName, string playerMessage)
        // while vieweing profiles, the first thing we are doing is we are UPDATING the text values. 
        // we are working with DUMMY DATA. so based on the player's name which we clicked on home page, we access that text
        // and respectively we access their TMP_Text from the children. 
    {
        followers = Random.Range(0, 9999);
        followersTxt.text = $"Followers: {followers}";
        playerLoad = playerName;
        viewPlayerName.text = playerName;

        var findTxt = firstMsgObj.GetComponentsInChildren<TMP_Text>();
        TMP_Text playerNameVal = findTxt[0];
        TMP_Text playerMsg = findTxt[1];

        playerNameVal.text = playerLoad;
        playerMsg.text = playerMessage;

        InstantiateMessages(playerNameVal.text);
    }

    public void InstantiateMessages(string playerName_)
    {
        for(int i = 0; i < 10; i++)
        {
            int messagesToShowIndx = Random.Range(0, 25);
            string messageToShow = pageHome.randomMessages[messagesToShowIndx];

            GameObject msgBox = Instantiate(messageBoxObj, messageBoxParent.transform);
            var msgBoxBreak = msgBox.GetComponentsInChildren<TMP_Text>();
            TMP_Text playerName = msgBoxBreak[0];
            TMP_Text messageHold = msgBoxBreak[1];

            playerName.text = playerName_;
            messageHold.text = messageToShow;
        }
    }
}