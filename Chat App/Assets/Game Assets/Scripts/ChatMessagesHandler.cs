using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatMessagesHandler : MonoBehaviour
{
    public static ChatMessagesHandler instance;
    public Button onSendMessage;
    public TMP_InputField inpFieldTxt;
    public string messageToPost;
    public GameObject messageToPost_Obj;
    public Transform messageParent;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        onSendMessage.onClick.AddListener(SendMessage);
    }

    void SendMessage()
    {
        GameObject instantiatedObj = Instantiate(messageToPost_Obj, messageParent);
        TMP_Text[] instantiatedObj_Text = instantiatedObj.GetComponentsInChildren<TMP_Text>();
        var playerName = instantiatedObj_Text[0];
        var message = instantiatedObj_Text[1];
        messageToPost = inpFieldTxt.text;
        playerName.text = GameManager.instance.playerName;
        message.text = messageToPost;

        inpFieldTxt.text = string.Empty;
    }

    public void DestroyChildren()
    {
        foreach (Transform child in messageParent)
        {
            Destroy(child.gameObject);
        }
    }
}
