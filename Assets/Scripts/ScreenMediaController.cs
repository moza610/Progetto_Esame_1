using UnityEngine;

public class ScreenMediaController : MonoBehaviour
{
    public AudioSource clickAudio;
    public GameObject memePlane; // il plane col meme, disattivato di default

    private bool isOn = false;

    void Start()
    {
        if (memePlane != null)
            memePlane.SetActive(false);
    }

    public void ToggleMedia()
    {
        isOn = !isOn;

        if (clickAudio != null)
            clickAudio.Play();

        if (memePlane != null)
            memePlane.SetActive(isOn);
    }
}