using UnityEngine;

public class ClickableScreen : MonoBehaviour
{
    // Questi sono i materiali originali della tua amica
    public Material ScreenRed;
    public Material ScreenGreen;

    // LE TUE AGGIUNTE: Spazi per l'audio e l'immagine
    public AudioSource ClickAudio;      
    public GameObject ImmagineSchermo;  
    private Renderer rend;
    private bool isOn = false;
    

    public DoorController puzzleManager; // per far aprire la porta con il puzze risolto
    public int screenIndex;     // sequenza per puzzle1
    void Start()
    {
        rend = GetComponent<Renderer>();
        if (ScreenRed != null && rend != null)
        {
            rend.material = ScreenRed; 
        }

        // All'inizio spegniamo la tua immagine
        if (ImmagineSchermo != null)
        {
            ImmagineSchermo.SetActive(false);
        }
    }

    public void ToggleColor()
    {
        isOn = !isOn;
        
        // Quando clicchi, fa partire il tuo audio
        if (ClickAudio != null)
        {
            ClickAudio.Play();
        }

        // Quando clicchi, accende/spegne la tua immagine
        if (ImmagineSchermo != null)
        {
            ImmagineSchermo.SetActive(isOn);
        }
        
       
        if (isOn == true)
        {
            rend.material = ScreenGreen;
        }
        else
        {
            rend.material = ScreenRed;
        }
        
        
        if (puzzleManager != null)
        {
            // Aggiorna lo stato nel manager
            puzzleManager.screenStates[screenIndex] = isOn;
            puzzleManager.CheckDoor();
        }
    } 
}