using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public TMP_Text playerName;
    public TMP_Text messageTxt;
    public Button buttonObj;
    public ProfileView viewProfile_;
    void Start()
    {
        buttonObj.onClick.AddListener(OnButtonClicked);
        viewProfile_ = FindAnyObjectByType<ProfileView>();
    }
    public void GetPlayerNameAndMessage()
    {
        viewProfile_ = FindAnyObjectByType<ProfileView>();
    }
    public void OnButtonClicked()
    {
        GameManager.instance.OpenMenu(3);
        viewProfile_.UpdateText(playerName.text, messageTxt.text);  
    }
}
