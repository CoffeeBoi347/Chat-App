using UnityEngine;
using UnityEngine.UI;

public class PlayAudio : MonoBehaviour
{
    [Header("Buttons")]

    public Button[] buttons;
    public AudioClip[] audioClip;
    public AudioSource audioSource;
    public Button stopButton;

    private void Start()
    {
        stopButton.onClick.AddListener(StopButton);

        foreach(var button in buttons)
        {
            button.onClick.AddListener( () => PlaySong(button));
        }
    }

    void PlaySong(Button buttonClicked)
    {
        var getAudioSource = buttonClicked.GetComponent<AudioSource>();
        if (getAudioSource != null)
        {
            var getAudioIndex = buttonClicked.GetComponent<AudioIndex>().audioIndex_;
            audioSource.Stop();
            audioSource.clip = audioClip[getAudioIndex];
            getAudioSource.loop = true;
            audioSource.Play();
        }
    }

    void StopButton()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
