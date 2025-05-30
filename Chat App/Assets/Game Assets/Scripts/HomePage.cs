using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HomePage : MonoBehaviour
{
    public Button homeButton;
    public int messagesToSpawn = 50;
    public GameObject messageBox;
    public Transform holdMsgs;
    public ProfileView viewProfile;
    public List<string> playerNames = new List<string>
    {
    "@coolTiger92",
    "@pixelNinja77",
    "@codeWizard99",
    "@fastRunner88",
    "@gamerGirlX",
    "@techGuru2025",
    "@happyCamper42",
    "@skyWalker23",
    "@nightOwl007",
    "@silentShadow55",
    "@cyberSamurai",
    "@mysticMage12",
    "@urbanExplorer",
    "@comicFanatic",
    "@musicLover101",
    "@movieBuff24",
    "@coffeeAddict7",
    "@travelBug89",
    "@bookWorm33",
    "@fitnessFreak9"
    };

    public List<string> randomMessages = new List<string>
        {
        "Just finished my late night session!, THAT WAS TIRING...",
        "Officially an intern now :)",
        "Hey fellas, what's up?",
        "Good morning everyone!",
        "Is anyone going to dev day 2025?",
        "GTA 6 looks so crazy ngl",
        "Can this post get a 100 likes?",
        "Mission Impossible 9!!! we want tom cruise back...!",
        "Going to the shopping mall now :)",
        "How is life?",
        "Hiring a junior unity developer, DM for more details. Can't disclose details in public!",
        "Bangalore traffic is way too much!",
        "Just got AIR 02 In JEE ADVANCED 2025",
        "Hey @MrBeast give me $100 please",
        "Good night everyone",
        "Man I am so sleepy ngl",
        "Chattrix is the best social media app!",
        "Brought my first home in Whitefield!",
        "Mannnn I hate going to college!",
        "Subscribe to my youtube channel everyone!",
        "Is it me or instagram is down for everyone?",
        "Hi everyone! New to this app."
    };

    private void Start()
    {
        ClickButton();
    }

    public void ClickButton()
    {
        homeButton.onClick.AddListener(GenerateRandomMessages);

    }

    void GenerateRandomMessages()
    {
        for (int i = 0; i < randomMessages.Count; i++)
        {
            GameObject spawnObj = Instantiate(messageBox.gameObject, holdMsgs);
            var getTxt = spawnObj.GetComponentsInChildren<TMP_Text>();

            int getPlayerIndex = Random.Range(0, playerNames.Count);
            int getMessageIndex = Random.Range(0, randomMessages.Count);
            TMP_Text playerNameTxt = getTxt[0];
            TMP_Text messageNameTxt = getTxt[1];
            playerNameTxt.text = playerNames[getPlayerIndex].ToString();
            messageNameTxt.text = randomMessages[getMessageIndex];

            var spawnChild = spawnObj.GetComponentInChildren<ButtonHandler>();
            spawnChild.viewProfile_ = viewProfile;
            viewProfile = FindObjectOfType<ProfileView>();

        }
    }

}
