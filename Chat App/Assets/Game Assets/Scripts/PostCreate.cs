using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PostCreate : MonoBehaviour
{
    [Header("UI Elements")]

    public Button submitButton;
    public TMP_InputField inpField;

    [Header("Store Message")]

    public string messageToPost;

    private void Start()
    {
        submitButton.onClick.AddListener(OnSubmitButtonPressed);
    }

    void OnSubmitButtonPressed()
    {
        messageToPost = inpField.text;
        inpField.text = string.Empty;
    }
}