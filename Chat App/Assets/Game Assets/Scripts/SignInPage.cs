using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SignInPage : MonoBehaviour
{
    public GameManager gameManager;
    public TMP_InputField playerName;
    public TMP_InputField password;
    public GameObject headerObj;
    public string playerName_;
    public string passwordName_;

    public Button clickButton;
    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            GameManager.instance.OpenMenu(1);
            OpenHeader();
        }
        else
        {
            Debug.Log("Clicking...");
            clickButton.onClick.AddListener(OnClickButton);
        }
    }


    public void OnClickButton()
    {
        playerName_ = playerName.text;
        passwordName_ = password.text;
        GameManager.instance.playerName = playerName_;

        if (!string.IsNullOrEmpty(playerName_) && !string.IsNullOrEmpty(passwordName_))
        {
            PlayerPrefs.SetString("PlayerName", playerName_);
            headerObj.SetActive(true);
            GameManager.instance.OpenMenu(1);
        }
    }

    public void OpenHeader()
    {
        headerObj.SetActive(true);
    }
}
