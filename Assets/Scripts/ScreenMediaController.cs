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
        Debug.Log("Stato dello schermo cambiato. Nuovo stato: " + (isOn ? "ACCESO" : "SPENTO"));

        if (clickAudio != null)
        {
            clickAudio.Play();
        }
        else
        {
            Debug.LogWarning("ATTENZIONE: La casella clickAudio è VUOTA nell'Inspector!");
        }

        if (memePlane != null)
        {
            memePlane.SetActive(isOn);
        }
        else
        {
            Debug.LogWarning("ATTENZIONE: La casella memePlane è VUOTA nell'Inspector!");
        }
    }
}