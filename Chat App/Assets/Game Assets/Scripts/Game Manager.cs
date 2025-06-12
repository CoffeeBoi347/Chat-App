using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<GameObject> panels = new List<GameObject>();
    public string playerName;

    [Header("Buttons")]

    public GameObject headerObj;
    public Button homeButton;
    public Button postButton;
    public Button viewProfileButton;
    public Button musicButton;
    public Button quitButton;
    public Button deleteDataButton;
    public bool deletePlayerPrefs = false;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        DeletePlayerPrefs();
        if (!PlayerPrefs.HasKey("PlayerName"))
        {
            OpenMenu(6);
        }

        else
        {
            OpenMenu(1);
            headerObj.gameObject.SetActive(true);
        }

        homeButton.onClick.AddListener(OpenHomeButton);
        postButton.onClick.AddListener(OpenPostButton);
        viewProfileButton.onClick.AddListener(OpenViewProfileButton);
        quitButton.onClick.AddListener(OnApplicationQuit);
        musicButton.onClick.AddListener(OpenMusicButton);
        deleteDataButton.onClick.AddListener(OnDeleteData);
    }

    void DeletePlayerPrefs()
    {
        if (deletePlayerPrefs)
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void OpenMenu(int index)
    {
        playerName = PlayerPrefs.GetString("PlayerName");
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

    public void OpenMusicButton()
    {
        OpenMenu(5);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    public void OnDeleteData()
    {
        PlayerPrefs.DeleteAll();
    }
}