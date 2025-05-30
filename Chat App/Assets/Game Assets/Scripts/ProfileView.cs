using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProfileView : MonoBehaviour
{
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

    private void Awake()
    {
        instance = this;
    }
    public void UpdateText(string playerName, string playerMessage)
    {
        playerLoad = playerName;
        viewPlayerName.text = playerName;

        var findTxt = firstMsgObj.GetComponentsInChildren<TMP_Text>();
        TMP_Text playerNameVal = findTxt[0];
        TMP_Text playerMsg = findTxt[1];

        playerNameVal.text = playerName;
        playerMsg.text = playerMessage;

        InstantiateMessages();
    }

    public void InstantiateMessages()
    {
        for(int i = 0; i < 10; i++)
        {
            int messagesToShowIndx = Random.Range(0, 15);
            string messageToShow = pageHome.randomMessages[messagesToShowIndx];

            GameObject msgBox = Instantiate(messageBoxObj, messageBoxParent.transform);
            var msgBoxBreak = msgBox.GetComponentsInChildren<TMP_Text>();
            TMP_Text playerName = msgBoxBreak[0];
            TMP_Text messageHold = msgBoxBreak[1];

            playerName.text = playerLoad;
            messageHold.text = messageToShow;
        }
    }
}