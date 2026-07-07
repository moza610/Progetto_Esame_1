using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleDoorCode : MonoBehaviour
{
    public string CorrectCode = "124569";
    private Renderer rend;
    public TMP_InputField UIPswDoor;
    private bool isKeyboardActive = false;
    public Material ScreenGreen;
    public Material ScreenRed;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      rend = GetComponent<Renderer>(); // Prende il renderer di QUESTO oggetto

      if (UIPswDoor != null)
    {
        UIPswDoor.gameObject.SetActive(false);
    }
    }

    //attiviamo il tastierino per inserire la password
        public void ActiveKeyboard()
    {
        Debug.Log("Il comando è arrivato! Sto aprendo la tastiera."); // Aggiungi questa riga
         if (UIPswDoor != null)
    {
        UIPswDoor.gameObject.SetActive(true);
    }
        UIPswDoor.text = ""; // Pulisce il testo precedente

        UIPswDoor.Select();
        UIPswDoor.ActivateInputField();

        isKeyboardActive = true; // Impostiamo a vero quando si apre
     
    }

    //controlla se la psw è corretta
    public void CheckPassword(string Input)
    {
        if (Input.Trim() == CorrectCode)
        {
            Debug.Log("Password CORRETTA");
            if (rend != null) 
            {
                // Cambia il materiale del modello 3D
                rend.material = ScreenGreen;
            }
        }
        else
        {
            Debug.Log("Password SBAGLIATA");
            if (rend != null) 
            {
                rend.material = ScreenRed;
                UIPswDoor.text = "";
                UIPswDoor.ActivateInputField();
            }
        }
    }

    void CloseKeyboard() 
    {
      isKeyboardActive = false; // Impostiamo a falso quando si chiude
      Cursor.lockState = CursorLockMode.Locked; // Blocca il mouse 
    }
    
    // Update is called once per frame
    void Update()
    {
     // premi ESC, allora chiudi
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIPswDoor.gameObject.SetActive(false);
            
        }   
    //quando premi invio si verifica la password
        if (isKeyboardActive && Input.GetKeyDown(KeyCode.Return))
    {
        CheckPassword(UIPswDoor.text);
    }
    
  
    
    }
}
