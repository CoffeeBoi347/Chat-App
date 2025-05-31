using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpenChatBox : MonoBehaviour
{
    public bool allowedToChangeVal = false;
    public Button chatButton;
    public int chatBoxMsgs;
    public TMP_Text chatBoxTxt;
    public ChatMessagesHandler chatMessagesHandler;
    private void Start()
    {
        chatMessagesHandler = ChatMessagesHandler.instance;
        chatButton.onClick.AddListener(OpenChatPanel);
        if (allowedToChangeVal)
        {
            chatBoxMsgs = Random.Range(0, 100);
        }
        chatBoxTxt.text = chatBoxMsgs.ToString();
    }

    void OpenChatPanel()
    {
        chatMessagesHandler.DestroyChildren();
        GameManager.instance.OpenMenu(4);
    }
}