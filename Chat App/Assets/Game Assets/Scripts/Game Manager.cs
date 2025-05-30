using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> panels = new List<GameObject>();

    [Header("Buttons")]

    public Button homeButton;
    public Button postButton;
    public Button viewProfileButton;
    public Button quitButton;

    private void Start()
    {
        OpenMenu(0);
        homeButton.onClick.AddListener(OpenHomeButton);
        postButton.onClick.AddListener(OpenPostButton);
        viewProfileButton.onClick.AddListener(OpenViewProfileButton);
        quitButton.onClick.AddListener(OnApplicationQuit);
    }

    public void OpenMenu(int index)
    {
        for (int i = 0; i < panels.Count; i++)
        {
            var obj = panels[i].GetComponent<CanvasGroup>();
            obj.gameObject.SetActive(false);
            obj.alpha = 0;
            obj.interactable = false;
            obj.blocksRaycasts = false;

            var obj2 = panels[index].GetComponent<CanvasGroup>();
            obj2.gameObject.SetActive(true);
            obj2.alpha = 1;
            obj2.interactable = true;
            obj2.blocksRaycasts = true;
        }
    }

    public void OpenHomeButton()
    {
        OpenMenu(0);
    }

    public void OpenPostButton()
    {
        OpenMenu(1);
    }

    public void OpenViewProfileButton()
    {
        OpenMenu(2);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}